﻿using System;
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
                    { "f", "#FFFFFF" }
        };
    }
}
