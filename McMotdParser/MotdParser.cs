using System.Runtime.InteropServices;
using System.Text.Json;
using McMotdParser.Deserializer;

namespace McMotdParser
{
    public class Motd
    {
        private string RawMotd;
        public Motd(string raw_motd)
        {
            this.RawMotd = raw_motd;
        }

        public void ToXaml()
        {

        }
        public string ToHtml()
        {
            return "";
        }

        private string DefiniteForm()
        {
            return string.Empty;
        }

        private MotdContent aa(){
            var option = new JsonSerializerOptions();
            option.Converters.Add(new JsonDeserializer<MotdContent>());
            return JsonSerializer.Deserialize<MotdContent>(this.RawMotd);
        }
    }
}