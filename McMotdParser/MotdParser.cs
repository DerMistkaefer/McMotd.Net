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
            RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);
            RawMotd = StringUtils.ToJsonObjectString(RawMotd);
            
            var contents = this.deserialize(RawMotd);
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<div class=""mcmotd-container"">");
            foreach (var content in contents)
            {
                sb.Append("<span");
                sb.Append($" style=\"color:{content.Color};\"");
                sb.Append(">");
                if (content.LineBreak) sb.Append("<br/>");
                sb.Append(content.Text.Replace(" ","&nbsp;" ));
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
                        sb.Append("mcmotd-text-bold");
                        break;
                    case TextFormatEnum.Italic:
                        sb.Append("mcmotd-text-italic");
                        break;
                    case TextFormatEnum.Underline:
                        sb.Append("mcmotd-text-underline");
                        break;
                    case TextFormatEnum.Striktethrough:
                        sb.Append("mcmotd-text-strikethrough");
                        break;
                    default:
                        sb.Append("mcmotd-text-normal");
                        break;
                }

                sb.Append(";");
            }

            return "";
        }
        public List<MotdContent> deserialize(string RawMotd){
            var option = new JsonSerializerOptions();
            option.Converters.Add(new MotdDeserializer());
            return JsonSerializer.Deserialize<MotdContents>(RawMotd,option).Contents;
        }
        
    }


    
}