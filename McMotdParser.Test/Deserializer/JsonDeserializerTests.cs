using McMotdParser.Deserializer;
using McMotdParser.Enum;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Diagnostics;
using System.Text.Json;
using Xunit;

namespace McMotdParser.Test.Deserializer
{
    public class JsonDeserializerTests
    {
        [Fact]
        public void SimpleJsonMotdDeserialize()
        {
            string raw_motd = @"{""text"":""기모찌서버""}";
            var testResult = new MotdParser(raw_motd).testFunc();

            MotdContents contents= new MotdContents();
            List<MotdContent> expect = new List<MotdContent>()
            {
                new MotdContent() { color =  null, content = "기모찌서버", TextFormatting = { TextFormatEnum.Noraml }  }
            };
            contents.Contents = expect;

            Assert.True(testResult.Equals(contents));
        }
        [Fact]
        public void ComplexJsonMotdDeserialize()
        {
            //string raw_motd = @"{""extra"":[{""color"":""aqua"",""text"":""◆ ""},{""bold"":true,""italic"":true,""color"":""#00ffff"",""text"":""스""},{""bold"":true,""italic"":true,""color"":""#19e5ff"",""text"":""티""},{""bold"":true,""italic"":true,""color"":""#33ccff"",""text"":""브""},{""bold"":true,""italic"":true,""color"":""#4cb2ff"",""text"":""""},{""bold"":true,""italic"":true,""color"":""#6699ff"",""text"":""갤""},{""bold"":true,""italic"":true,""color"":""#7f7fff"",""text"":""러""},{""bold"":true,""italic"":true,""color"":""#9966ff"",""text"":""리""},{""bold"":true,""italic"":true,""color"":""#b24cff"",""text"":""""},{""bold"":true,""italic"":true,""color"":""#cc32ff"",""text"":""놀""},{""bold"":true,""italic"":true,""color"":""#e519ff"",""text"":""이""},{""bold"":true,""italic"":true,""color"":""#ff00ff"",""text"":""터""},{""color"":""light_purple"",""text"":"" ◆\r\n""},{""color"":""gray"",""text"":""건축\/쉼터""}],""text"":""""}";
            string raw_motd = "{\"extra\":[{\"color\":\"aqua\",\"text\":\"◆ \"},{\"bold\":true,\"italic\":true,\"color\":\"#00ffff\",\"text\":\"스\"},{\"bold\":true,\"italic\":true,\"color\":\"#19e5ff\",\"text\":\"티\"},{\"bold\":true,\"italic\":true,\"color\":\"#33ccff\",\"text\":\"브\"},{\"bold\":true,\"italic\":true,\"color\":\"#4cb2ff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#6699ff\",\"text\":\"갤\"},{\"bold\":true,\"italic\":true,\"color\":\"#7f7fff\",\"text\":\"러\"},{\"bold\":true,\"italic\":true,\"color\":\"#9966ff\",\"text\":\"리\"},{\"bold\":true,\"italic\":true,\"color\":\"#b24cff\",\"text\":\"\"},{\"bold\":true,\"italic\":true,\"color\":\"#cc32ff\",\"text\":\"놀\"},{\"bold\":true,\"italic\":true,\"color\":\"#e519ff\",\"text\":\"이\"},{\"bold\":true,\"italic\":true,\"color\":\"#ff00ff\",\"text\":\"터\"},{\"color\":\"light_purple\",\"text\":\" ◆\r\n\"},{\"color\":\"gray\",\"text\":\"건축/쉼터\"}],\"text\":\" \"\"}";
            
            var testResult = new MotdParser(raw_motd).testFunc();
            MotdContents contents = new MotdContents();
            
            List<MotdContent> expect = new List<MotdContent>()
            {
                new MotdContent{ color = "#55FFFF", content = "◆ "},
                new MotdContent{ color = "#00ffff", content = "스", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#19e5ff", content = "티", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#33ccff", content = "브", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#4cb2ff", content = "", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#6699ff", content = "갤", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#7f7fff", content = "러", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#9966ff", content = "리", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#b24cff", content = "", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#cc32ff", content = "놀", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#e519ff", content = "이", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#ff00ff", content = "터", TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold,TextFormatEnum.Italic } },
                new MotdContent{ color = "#FF55FF", content = " ◆\r\n" },
                new MotdContent{ color = "#AAAAAA", content = "건축/쉼터" },
            };

            contents.Contents = expect;
            Assert.True(testResult.Equals(contents));
        }

        [Fact]  
        public void SectionSignMotdDeserialize()
        {
            string raw_motd = "                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";


            var testResult = new MotdParser(raw_motd).testFunc();
            MotdContents contents = new MotdContents();

            List<MotdContent> except = new List<MotdContent>()
            {
                new MotdContent{ color = "#808080", content = "               "},
                new MotdContent{ color = "#55FF55", content = "Hypixel Network "},
                new MotdContent{ color = "#FF5555", content = "[1.8-1.20]\r\n        "},
                new MotdContent{ color = "#55FFFF", content = "DROPPER v1.0 ",TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold } },
                new MotdContent{ color = "#AAAAAA", content = "- "},
                new MotdContent{ color = "#FFAA00", content = "NEW ARCADE LOBBY",TextFormatting = new HashSet<TextFormatEnum> { TextFormatEnum.Bold }}
            };

            contents.Contents = except;

            Assert.True(testResult.Equals(contents));
        }

        [Fact]
        public void Replace()
        {
            string raw = "a\rb";
            raw = raw.Replace("\r", "");
            string expect = "ab";
            Assert.True(raw == expect);
        }
    }
}
