using McMotdParser.Utils;

namespace McMotdParser{
    public static class MotdParserRazorExtension
    {
        public static List<MotdContent> ToRazor(this MotdParser parser,string RawMotd)
        {
            
            string raw = RawMotd;
            
            raw = raw.Replace(" ", "&nbsp;");
            raw = StringUtils.EscapeCharacterReplace(raw);
            raw = StringUtils.ToJsonObjectString(raw);
            return parser.deserialize(raw);;
        }
    }


}