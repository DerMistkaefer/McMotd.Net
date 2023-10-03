using McMotdParser.Utils;

namespace McMotdParser.Test.Utils;

public class StringUtilsTest
{
    [Fact]
    public void EscapeCharacterReplace()
    {
        string raw = "\r\n";
        //string raw = StringUtils.EscapeCharacterReplace("\r\n"); //it's work
        //string raw = "\r\n".Replace("\r\n","§z§x"); //it's work

        string expect = "§z§x";
        
        Assert.Equal(StringUtils.EscapeCharacterReplace(raw),expect); //it's work
    }

    [Theory]
    [InlineData("[1.8-1.20]\r\n")]
    public void TestMoreSimilarReal(string RawMotd)
    {
        //RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);
        RawMotd = StringUtils.ToJsonObjectString(RawMotd);

        string expect = "[1.8-1.20]§z§x";
        
        Assert.Equal(RawMotd,expect);

    }
}