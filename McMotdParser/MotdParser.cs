using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using McMotdParser.Data;
using McMotdParser.Deserializer;
using McMotdParser.Enum;
using McMotdParser.Utils;

namespace McMotdParser
{
    public class MotdParser
    {

        
        
        public List<MotdContent> ToTest(string RawMotd)
        {
            
            RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);
            RawMotd = StringUtils.ToJsonObjectString(RawMotd);
            return this.deserialize(RawMotd);
        }
        //inconstruct
        //TOOD: Adding Style
        public string ToHtml(string RawMotd)
        {
            var contents = this.deserialize(RawMotd);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<div class=""mcmotd-container"">");
            foreach (var content in contents)
            {
                sb.Append("<span");
                sb.Append($" style=\"color:{content.Color};");
                sb.Append(HtmlStyle(content.TextFormatting));
                sb.Append("\">");
                if (content.LineBreak) sb.Append("<br/>");
                sb.Append(content.Text.Replace(" ","&nbsp;"));
                sb.Append("</span>");
            }
            sb.Append("</div>");
            return sb.ToString();
        }

        private string HtmlStyle(HashSet<TextFormatEnum> TextFormats)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var TextFormat in TextFormats)
            {
                sb.Append(" ");
                switch (TextFormat)
                {
                    case TextFormatEnum.Bold:
                        sb.Append("font-weight : bolder");
                        break;
                    case TextFormatEnum.Italic:
                        sb.Append("font-style : italic");
                        break;
                    case TextFormatEnum.Underline:
                        sb.Append("text-decoration : underline");
                        break;
                    case TextFormatEnum.Striktethrough:
                        sb.Append("text-decoration : line-through");
                        break;
                    default:
                        break;
                }

                sb.Append(";");
            }

            return sb.ToString();
        }
        public List<MotdContent> deserialize(string RawMotd)
        {
            RawMotd = new StringUtilBuilder()
                            .setString(RawMotd)
                            .EscapeCharacterReplace()
                            .ToJsonObjectString()
                            .build();
            
            
            var option = new JsonSerializerOptions();
            option.Converters.Add(new MotdDeserializer());
            return JsonSerializer.Deserialize<MotdContents>(RawMotd,option).Contents;
        }
        
    }


    
}