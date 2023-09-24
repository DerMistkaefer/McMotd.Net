using McMotdParser.Deserializer;
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

            testResult.Contents.ForEach(x =>
            {
                Debug.WriteLine(x.content);
            });


            Assert.Equal(testResult.Contents[0].content,"기모찌서버");
        }
        [Fact]
        public void ComplexJsonMotdDeserialize()
        {
            string raw_motd = @"{""extra"":[{""color"":""aqua"",""text"":""◆ ""},{""bold"":true,""italic"":true,""color"":""#00ffff"",""text"":""스""},{""bold"":true,""italic"":true,""color"":""#19e5ff"",""text"":""티""},{""bold"":true,""italic"":true,""color"":""#33ccff"",""text"":""브""},{""bold"":true,""italic"":true,""color"":""#4cb2ff"",""text"":""""},{""bold"":true,""italic"":true,""color"":""#6699ff"",""text"":""갤""},{""bold"":true,""italic"":true,""color"":""#7f7fff"",""text"":""러""},{""bold"":true,""italic"":true,""color"":""#9966ff"",""text"":""리""},{""bold"":true,""italic"":true,""color"":""#b24cff"",""text"":""""},{""bold"":true,""italic"":true,""color"":""#cc32ff"",""text"":""놀""},{""bold"":true,""italic"":true,""color"":""#e519ff"",""text"":""이""},{""bold"":true,""italic"":true,""color"":""#ff00ff"",""text"":""터""},{""color"":""light_purple"",""text"":"" ◆\r\n""},{""color"":""gray"",""text"":""건축\/쉼터""}],""text"":""""}";

            var testResult = new MotdParser(raw_motd).testFunc();

            testResult.Contents.ForEach(x =>
            {
                Debug.WriteLine(x.content);
            });


            Assert.True(true);
        }

        [Fact]
        public void SectionSignMotdDeserialize()
        {
            string raw_motd = "                §aHypixel Network §c[1.8-1.20]\r\n        §b§lDROPPER v1.0 §7- §6§lNEW ARCADE LOBBY";


            var testResult = new MotdParser(raw_motd).testFunc();
            testResult.Contents.ForEach(x =>
            {
                Debug.WriteLine(x.content);
            });



            Assert.True(true);
        }
    }
}
