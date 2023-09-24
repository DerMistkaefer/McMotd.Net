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
        public SectionSignDeserializer(string raw_content) {
            this.raw_content = raw_content;

        }
        //TODO : 앞뒤 따음표 없애기
        public List<MotdContent> deserialize(){
            List<MotdContent> MotdContents = new List<MotdContent> ();
            var splited_contents = this.raw_content.Split(SIGN);
            for(int i = 0; i< splited_contents.Length; i++) {
                if(i == 0)
                {
                    if (splited_contents[i] == string.Empty) continue;
                }
                MotdContents.Add(new MotdContent()
                {
                    content = splited_contents[i]
                });



            }
            return MotdContents;
        }
        private string FirstSignParse(string content)
        {
            return "";
        }
    }
}
