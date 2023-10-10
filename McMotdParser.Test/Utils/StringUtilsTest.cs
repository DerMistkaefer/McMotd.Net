using System.Diagnostics.CodeAnalysis;
using McMotdParser.MAUI.Extensions;
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

        string expect = "§x§z";
        
        Assert.Equal(StringUtils.EscapeCharacterReplace(raw),expect); //it's work
    }

    [Theory]
    [InlineData("[1.8-1.20]\r\n")]
    [InlineData("[1.8-1.20]\r\n    ")]
    public void TestMoreSimilarReal(string RawMotd)
    {
        //RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);
        RawMotd = StringUtils.EscapeCharacterReplace(RawMotd);

        string expect = "[1.8-1.20]§x§z    ";
        
        Assert.Equal(expect,RawMotd);

    }

    [Fact]
    public void QuotePlaceTest()
    {
        string text = "12345";
        
        string expect = @"""12345""";
        
        Assert.Equal(expect,StringUtils.QuotesPlace(text));
    }

    [Fact]
    public void ToXamlTest()
    {
        string text = "\r\n";
        string expect = "§x§z";
        Assert.Equal(expect, new MotdParser().ToXaml(text).FirstOrDefault().Text);
    }
}