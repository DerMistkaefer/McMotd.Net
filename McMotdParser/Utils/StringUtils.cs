using System.Diagnostics;
using System.Text;

namespace McMotdParser.Utils;

public class StringUtils
{
    /// <summary>
    /// This is a string converter for custom deserializers.
    /// </summary>
    /// <param name="motd">any motd string</param>
    /// <returns>{ Contents : "{any motd string}"}</returns>
    public static string ToJsonObjectString(string motd)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("{ \"Contents\" : ");
        
        //determine using "Section Sign"
        //bool isStartObject = !motd.StartsWith("{");
        
        //if (isStartObject) sb.Append('\"');
        sb.Append(motd);
        //if (isStartObject) sb.Append('\"');
        sb.Append(" }");
            
        return sb.ToString();
    }

    public static string EscapeCharacterReplace(string motd)
    {
        return motd.Replace("\r", "§x").Replace("\n", "§z");
    }

    public static string QuotesReplace(string motd)
    {
        if (motd.StartsWith(@""""))
        {
            motd = motd.Substring(2, motd.Length - 3);
        }

        return motd;
    }
}