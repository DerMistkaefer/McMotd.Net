


using McMotdParser.Utils;

namespace McMotdParser{
    public static class MotdParserRazorExtension
    {
        public static List<MotdContent> ToRazor(this MotdParser parser,string RawMotd)
        {
            

            return parser.deserialize(StringUtils.ToJsonObjectString(RawMotd));;
        }
    }


}