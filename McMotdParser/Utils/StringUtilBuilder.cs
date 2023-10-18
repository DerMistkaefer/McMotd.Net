namespace McMotdParser.Utils;

public class StringUtilsBuilder
{
    private string RawMotd;

    public string build()
    {
        if (RawMotd is null) throw new ArgumentNullException("RawMotd is not setted");
        return RawMotd;
    }

    public StringUtilsBuilder setString(string RawMotd)
    {
        this.RawMotd = RawMotd;
        return this;
    }
    public StringUtilsBuilder QuotePlace()
    {
        this.RawMotd = StringUtils.QuotesPlace(this.RawMotd);
        return this;
    }

    public StringUtilsBuilder ToJsonObjectString()
    {
        this.RawMotd = StringUtils.ToJsonObjectString(this.RawMotd);
        return this;
    }

    public StringUtilsBuilder EscapeCharacterReplace()
    {
        this.RawMotd = StringUtils.EscapeCharacterReplace(this.RawMotd);
        return this;
    }
    
}