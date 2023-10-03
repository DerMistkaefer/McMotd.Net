using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using McMotdParser.Data;
using McMotdParser.Deserializer;
using McMotdParser.Utils;

namespace McMotdParser
{
    public class MotdParser
    {


        //inconstruct
        public string ToHtml(string RawMotd)
        {
            
            return string.Empty;
        }

        public List<MotdContent> ToTest(string RawMotd)
        {
            RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);
            RawMotd = StringUtils.ToJsonObjectString(RawMotd);
            return this.deserialize(RawMotd);
        }

        public List<MotdContent> deserialize(string RawMotd){
            var option = new JsonSerializerOptions();
            option.Converters.Add(new MotdDeserializer());
            return JsonSerializer.Deserialize<MotdContents>(RawMotd,option).Contents;
        }
    }


    
}