using McMotdParser.Deserializer;
using McMotdParser.Enum;
using System.Text.Json.Serialization;

namespace McMotdParser;
public class MotdContent
{
    public string color { get; set; } = "#808080";
    public string content { get; set; }
    public HashSet<TextFormatEnum> TextFormatting { get; set; } = new HashSet<TextFormatEnum>();

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (!(obj.GetType() == typeof(MotdContent))) return false;

        var target = (MotdContent)obj;
        if (this.content != target.content) return false;
        if (this.color != target.color) return false;
        //if(this.TextFormatting.Equals(target.TextFormatting)) return false;
        if (this.TextFormatting.Count != target.TextFormatting.Count) return false;
        return true;
    }
}


public class MotdContents
{
    [JsonConverter(typeof(MotdDeserializer))]
    public List<MotdContent> Contents { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (!(obj.GetType() == typeof(MotdContents))) return false;

        var targets = (MotdContents)obj;

        for (int i = 0; i < Contents.Count; i++)
        {
            var content = Contents[i];
            var target = targets.Contents[i];
            if (!content.Equals(target)) return false;
        }

        return true;
    }
}