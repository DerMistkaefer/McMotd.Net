using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using McMotdParser.Deserializer;

namespace McMotdParser
{
    public class MotdParser
    {
        private string RawMotd;
       

        public MotdParser(string raw_motd)
        {
            this.RawMotd = DefiniteForm(raw_motd);
        }

        public void ToXaml()
        {

        }
        public string ToHtml()
        {
            return "";
        }

        private string DefiniteForm(string raw_motd)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ \"Contents\" : ");
            if (!raw_motd.StartsWith('{')) sb.Append('\"');
            sb.Append(raw_motd);
            if (!raw_motd.StartsWith('{')) sb.Append('\"');
            sb.Append('}');
            
            return sb.ToString();
        }

        public MotdContents testFunc(){
            var option = new JsonSerializerOptions();
            option.Converters.Add(new MotdDeserializer());
            return JsonSerializer.Deserialize<MotdContents>(this.RawMotd);
        }
    }

    public class MotdContents
    {
        [JsonConverter(typeof(MotdDeserializer))]
        public List<MotdContent > Contents { get; set; }
    }
    
}