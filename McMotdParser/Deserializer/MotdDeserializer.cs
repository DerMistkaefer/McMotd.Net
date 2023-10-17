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
            
            string? propertyName; // indicate first key
            
            List<MotdContent> contents = new List<MotdContent>();
            while (reader.Read())
            {
                reader.
                MotdContent motd = new MotdContent();
                propertyName = reader.GetString();
                
                if (reader.TokenType == JsonTokenType.EndObject) return contents;

                //Execute complex json motd deserialize
                //TODO : simplify,this code too complex
                if (propertyName == "extra")
                {
                    reader.Read();
                    if (reader.TokenType == JsonTokenType.StartArray)
                    {
                        while (reader.TokenType != JsonTokenType.EndArray)
                        {
                            reader.Read();
                            if (reader.TokenType == JsonTokenType.StartObject)
                            {
                                motd = ReadToEndObject(ref reader);
                            } 
                            //Execute skip StartObject

                            //Add MotdLine add
                            if (reader.TokenType == JsonTokenType.EndObject)
                            {
                                contents.Add(motd);
                                continue;
                            }
                            if (reader.TokenType == JsonTokenType.EndArray) {
                                reader.Read();
                                propertyName = reader.GetString();
                                break;
                            } //break, before reader.GetString()
                        }
                    }
                }
                else
                {
                    if (propertyName == "text")
                    {
                    }

                    if (!string.IsNullOrEmpty(value)) //temponary //this condition do filtering extra value
                    {
                        contents.Add(ReadToEndObject(ref reader));
                    }
                    continue;
                }
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, List<MotdContent> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        private MotdContent ReadToEndObject(ref Utf8JsonReader reader, MotdContent motd)
        {
            MotdContent motd = new MotdContent();
            string propertyName;
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return motd;
                }
                propertyName = reader.GetString();
                reader.Read();
                switch (propertyName)
                {
                    case "color":
                        string color = reader.GetString() ?? "#808080";
                        motd.Color = color.StartsWith("#") ? color : MotdData.ColorDict[color];
                        break;
                    case "bold":
                        if (reader.GetBoolean()) motd.TextFormatting.Add(TextFormatEnum.Bold);
                        break;
                    case "italic":
                        if (reader.GetBoolean()) motd.TextFormatting.Add(TextFormatEnum.Italic);
                        break;
                    case "text":
                        var value = reader.GetString();
                        if (nextLineBreak)
                        {
                            motd.LineBreak = true;
                            nextLineBreak = false;
                        }
                        if (value.Contains("§z"))
                        {
                            value = value.Replace("§z", "").Replace("§x","");
                            nextLineBreak = true;
                        }
                        motd.Text = string.IsNullOrEmpty(value) ? " " : value; //space add
                        break;
                }


            }
            return null;

        }

        private string getString(ref Utf8JsonReader reader)
        {
            reader.Read();
            return reader.GetString();
        }

        private bool getBoolen(ref Utf8JsonReader reader)
        {
            reader.Read();
            return reader.GetBoolean();
        }
    }
}
