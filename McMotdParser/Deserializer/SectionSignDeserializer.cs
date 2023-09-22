using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McMotdParser.Deserializer
{
    public class SectionSignDeserializer
    {
        private readonly string SIGN = "§";
        private string content;
        public SectionSignDeserializer(string content) {
            this.content = content;
    }

    }
}
