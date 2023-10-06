namespace McMotdParser.Utils;

public class StringUtilBuilder
{
    private string RawMotd;

    public string build()
    {
        if (RawMotd is null) throw new ArgumentNullException("RawMotd is not setted");
        return RawMotd;
    }

    public StringUtilBuilder setString(string RawMotd)
    {
        this.RawMotd = RawMotd;
        return this;
    }
    public StringUtilBuilder QuotePlace()
    {
        this.RawMotd = StringUtils.QuotesPlace(this.RawMotd);
        return this;
    }

    public StringUtilBuilder ToJsonObjectString()
    {
        this.RawMotd = StringUtils.ToJsonObjectString(this.RawMotd);
        return this;
    }

    public StringUtilBuilder EscapeCharacterReplace()
    {
        this.RawMotd = StringUtils.EscapeCharacterReplace(this.RawMotd);
        return this;
    }
    
}