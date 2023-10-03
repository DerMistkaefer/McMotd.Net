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
        public override List<MotdContent>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                using (var jsonDoc = JsonDocument.ParseValue(ref reader))
                {
                    return new SectionSignDeserializer(jsonDoc.RootElement.GetString()).deserialize();
                }
            }
            reader.Read();
            string? propertyName = reader.GetString(); //this indicate first key

            List<MotdContent> contents = new List<MotdContent>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return contents;

                MotdContent motd = new MotdContent();


                //Execute simple json motd deserialize
                if (propertyName == "text")
                {
                    string? value = reader.GetString();
                    if (!string.IsNullOrEmpty(value)) //temponary //this condition do filtering extra value
                    {
                        motd.Text = value;
                        motd.TextFormatting.Add(TextFormatEnum.Noraml);
                        //motd.LineBreak = value.EndsWith("§z§x");
                        contents.Add(motd);
                    }
                    continue;
                }
                //Execute complex json motd deserialize
                //TODO : simplify,this code too complex
                if (propertyName == "extra")
                {
                    //Array read
                    if (reader.TokenType == JsonTokenType.StartArray)
                    {
                        while (reader.TokenType != JsonTokenType.EndArray)
                        {
                            reader.Read();
                            if(reader.TokenType == JsonTokenType.StartObject) reader.Read(); //Execute skip StartObject

                            if (reader.TokenType == JsonTokenType.EndObject)
                            {
                               
                                contents.Add(motd);
                                motd = new MotdContent(); //reset
                                continue;
                            }
                            if (reader.TokenType == JsonTokenType.EndArray) {
                                reader.Read();
                                propertyName = reader.GetString();
                                break;
                            } //break, before reader.GetString()

                            propertyName = reader.GetString();
                            reader.Read();
                            switch (propertyName)
                            {
                                case "color":
                                    string color = reader.GetString() ?? "#808080";
                                    if (!color.StartsWith("#"))
                                    {
                                        color = MotdData.ColorDict[color];
                                    }
                                    
                                    motd.Color = color;
                                    break;
                                case "bold":
                                    if (reader.GetBoolean()) motd.TextFormatting.Add(TextFormatEnum.Bold);
                                    break;
                                case "italic":
                                    if (reader.GetBoolean()) motd.TextFormatting.Add(TextFormatEnum.Italic);
                                    break;
                                case "text":
                                    var value = reader.GetString();
                                    bool linebreak = value.Contains("§z§x");
                                    if (linebreak)
                                    {
                                        value = value.Replace("§z§x", "");
                                        motd.LineBreak = linebreak;
                                    }
                                    motd.Text = value;
                                    break;
                            }
                        }
                    }
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, List<MotdContent> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
