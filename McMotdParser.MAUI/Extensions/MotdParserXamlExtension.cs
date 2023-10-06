using McMotdParser.Utils;

namespace McMotdParser.MAUI.Extensions;

public static class MotdParserXamlExtension
{
    public static List<MotdContent> ToXaml(this MotdParser parser,string RawMotd)
    {
        return parser.deserialize(RawMotd); 
    }
        
}