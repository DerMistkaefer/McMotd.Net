using McMotdParser.Utils;

namespace McMotdParser.MAUI.Extensions;

public static class MotdParserXamlExtension
{
    public static List<MotdContent> ToXaml(this MotdParser parser,string RawMotd)
    {
        RawMotd = StringUtils.QuotesPlace(RawMotd);
        RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);
        RawMotd = StringUtils.ToJsonObjectString(RawMotd);
        return parser.deserialize(RawMotd); 
    }
        
}