using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMotdParser.Data
{
    partial class MotdData
    {
        public static Dictionary<string, string> ColorDict = new Dictionary<string, string>(){
                    { "0", "#000000" },
                    { "1", "#0000AA" },
                    { "2", "#00AA00" },
                    { "3", "#00AAAA" },
                    { "4", "#AA0000" },
                    { "5", "#AA00AA" },
                    { "6", "#FFAA00" },
                    { "7", "#AAAAAA" },
                    { "8", "#555555" },
                    { "9", "#5555FF" },
                    { "a", "#55FF55" },
                    { "b", "#55FFFF" },
                    { "c", "#FF5555" },
                    { "d", "#FF55FF" },
                    { "e", "#FFFF55" },
                    { "f", "#FFFFFF" },
                    { "black", "#000000" },
                    { "dark_blue", "#0000AA" },
                    { "dark_green", "#00AA00" },
                    { "dark_aqua", "#00AAAA" },
                    { "dark_red", "#AA0000" },
                    { "dark_purple", "#AA00AA" },
                    { "gold", "#FFAA00" },
                    { "gray", "#AAAAAA" },
                    { "dark_gray", "#555555" },
                    { "blue", "#5555FF" },
                    { "green", "#55FF55" },
                    { "aqua", "#55FFFF" },
                    { "red", "#FF5555" },
                    { "light_purple", "#FF55FF" },
                    { "yellow", "#FFFF55" },
                    { "white", "#FFFFFF" }
        };
    }
}
