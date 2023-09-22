using McMotdParser.Enum;

namespace McMotdParser;
public class MotdContent
{
    public string? color { get;set;}
    public string content {get;set;}
    public TextColorEnum TextFormatting {get;set;}

    public virtual void build() {}
}
