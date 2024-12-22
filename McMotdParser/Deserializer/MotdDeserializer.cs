using McMotdParser.Data;
using McMotdParser.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace McMotdParser.Deserializer
{
    internal class MotdDeserializer : JsonConverter<List<MotdContent>>
    {
        private bool nextLineBreak = false;
        public override List<MotdContent>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                using (var jsonDoc = JsonDocument.ParseValue(ref reader))
                {
                    return new SectionSignDeserializer(jsonDoc.RootElement.GetString()).deserialize();
                }
            }
            List<MotdContent> motdContents = new List<MotdContent>();
            
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                motdContents.Add(ParsingNode(root));
                if (root.TryGetProperty("extra",out var extra))
                {
                    foreach (var obj in extra.EnumerateArray())
                    {
                        motdContents.Add(ParsingNode(obj));
                    }
                }
            }

            return motdContents;
        }

        public override void Write(Utf8JsonWriter writer, List<MotdContent> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        private MotdContent ParsingNode(JsonElement element)
        {
            MotdContent motdContent = new MotdContent();
            foreach (var item in element.EnumerateObject())
            {
                ParsingObject(item, ref motdContent);
            }
            return motdContent;
        }

        private void ParsingObject(JsonProperty property,ref MotdContent motdContent)
        {
            var value = property.Value;
            switch (property.Name) {
                case "color": 
                    string color = value.GetString() ?? "#808080"; 
                    motdContent.Color = color.StartsWith("#") ? color : MotdData.ColorDict[color]; 
                    break;
                case "bold": 
                    if (value.GetBoolean()) motdContent.TextFormatting.Add(TextFormatEnum.Bold); 
                    break;
                case "italic": 
                    if (value.GetBoolean()) motdContent.TextFormatting.Add(TextFormatEnum.Italic); 
                    break; 
                case "text": 
                    var text = value.GetString(); 
                    if (nextLineBreak) 
                    { 
                        motdContent.LineBreak = true; 
                        nextLineBreak = false;
                    } 
                    if (text.Contains("§z")) 
                    { 
                        text = text.Replace("§z", "").Replace("§x",""); 
                        nextLineBreak = true;
                    } 
                    motdContent.Text = string.IsNullOrEmpty(text) ? " " : text;
                    break;
            }
        }

    }
}
