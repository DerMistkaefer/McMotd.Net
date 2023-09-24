using McMotdParser.Enum;

namespace McMotdParser;
public class MotdContent
{
    public string? color { get;set;}
    public string content {get;set;}
    public List<TextFormatEnum> TextFormatting { get; set; } = new List<TextFormatEnum>();

    public virtual void build() {}
}
