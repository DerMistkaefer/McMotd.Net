using McMotdParser.Data;
using McMotdParser.Enum;
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
        //TODO : replace new simple variable name
        public List<MotdContent> deserialize(){
            List<MotdContent> MotdContents = new List<MotdContent> ();

            var motd_content = new MotdContent();
            //plain text return 
            if (!this.raw_content.Contains(SIGN))
            {
                motd_content.Text = this.raw_content;
                MotdContents.Add(motd_content);
                return MotdContents;
            }
            var splited_contents = this.raw_content.Split(SIGN);

            for(int i = 0; i< splited_contents.Length; i++) {
                string raw_line = splited_contents[i];
                if(i == 0)
                {
                    if (string.IsNullOrEmpty(raw_line)) continue;
                    motd_content.Text = raw_line;
                    MotdContents.Add(motd_content);
                    motd_content = new MotdContent();
                    continue;
                }
                if (raw_line.Length == 1)
                {
                    SignParser(raw_line,ref motd_content);
                    continue;
                }
                //extract first character
                string SectionSign = raw_line[0].ToString();
                string text = raw_line.Substring(1);

                SignParser(SectionSign,ref motd_content);
                
                motd_content.Text = text;

                MotdContents.Add(motd_content);
                motd_content = new MotdContent();
            }
            return MotdContents;
        }
       private void SignParser(string content,ref MotdContent motd)
        {
            switch(content)
            {
                case "k":
                case "l":
                case "m":
                case "n":
                case "o":
                case "r":
                case "x": 
                    motd.TextFormatting.Add(MotdData.TextFormatDict[content]);
                    break;
                case "z":
                    motd.LineBreak = true;
                    break;
                default: 
                    motd.Color = MotdData.ColorDict[content];
                    break;
            }
        }
    }
}
