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
        private string raw_content;
        private StringBuilder sb;
        public SectionSignDeserializer(string raw_content) {
            this.raw_content = raw_content;

        }
        public void a(){
            var splited_contents = this.raw_content.Split(SIGN);
            foreach(var content in splited_contents){
                //Todo: Find run Sexy
                if(content.StartsWith(SIGN)){
                    var new_content = content.Substring(2);
                    
                }
            }
        }
    }
}
