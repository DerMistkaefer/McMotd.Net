using System.Diagnostics;
using System.Text;

namespace McMotdParser.Utils;

public class StringUtils
{
    /// <summary>
    /// This is a string converter for custom deserializers.
    /// </summary>
    /// <param name="motd">any motd string</param>
    /// <returns>{ Contents : {any motd string}}</returns>
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name="motd"></param>
    /// <returns>"some string §x§zstring"</returns>
    public static string EscapeCharacterReplace(string motd)
    {
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            return motd.Replace("\\r", "§x").Replace("\\n", "§z");
        }
        return motd.Replace("\r", "§x").Replace("\n", "§z");
        
    }
    public static string QuotesReplace(string motd)
    {
        if (motd.StartsWith(@""""))
        {
            return motd.Substring(2, motd.Length - 3);
        }

        return motd;
    }

    public static string QuotesPlace(string motd)
    {
        if (!motd.StartsWith("{"))
        {
            if (!motd.StartsWith(@""""))
            {
                return motd.Insert(0, "\"").Insert(motd.Length + 1 , "\""); //hmm...
            }
        }
        return motd;
    }
}