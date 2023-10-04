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
        private string RawMotd;
        public SectionSignDeserializer(string RawMotd) {
            this.RawMotd = RawMotd;
        }
        //TODO : replace new simple variable name
        public List<MotdContent> deserialize(){
            List<MotdContent> MotdContents = new List<MotdContent> ();

            var motdContent = new MotdContent();
            //plain text return 
            if (!this.RawMotd.Contains(SIGN))
            {
                motdContent.Text = this.RawMotd;
                MotdContents.Add(motdContent);
                return MotdContents;
            }
            var splitedRawMotd = this.RawMotd.Split(SIGN);
            
            for(int i = 0; i< splitedRawMotd.Length; i++) {
                string RawLine = splitedRawMotd[i];
                if(i == 0)
                {
                    if (string.IsNullOrEmpty(RawLine)) continue;
                    motdContent.Text = RawLine;
                    MotdContents.Add(motdContent);
                    motdContent = new MotdContent();
                    continue;
                }
                if (RawLine.Length == 1)
                {
                    SignParser(RawLine,ref motdContent);
                    continue;
                }
                //extract first character
                string SectionSign = RawLine[0].ToString();
                string text = RawLine.Substring(1);

                SignParser(SectionSign,ref motdContent);
                
                motdContent.Text = text;
                
                MotdContents.Add(motdContent);
                motdContent = new MotdContent();
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
