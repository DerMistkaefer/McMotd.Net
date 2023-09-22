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
    }
}