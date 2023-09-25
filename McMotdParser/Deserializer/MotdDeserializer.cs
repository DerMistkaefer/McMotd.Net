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
                Debug.WriteLine("Not Json Object");
                using (var jsonDoc = JsonDocument.ParseValue(ref reader))
                {
                    Debug.WriteLine($"string contents : {jsonDoc.RootElement.GetRawText()}");
                    return new SectionSignDeserializer(jsonDoc.RootElement.GetRawText()).deserialize();
                }
            }
            Debug.WriteLine("Object Found");
            reader.Read();
            string? propertyName = reader.GetString(); //this indicate first key

            List<MotdContent> contents = new List<MotdContent>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject) return contents;

                MotdContent motd = new MotdContent();

                Debug.WriteLine($"KEY PropertyName : {propertyName}");

                //Execute simple json motd deserialize
                if (propertyName == "text")
                {
                    Debug.WriteLine($"this section is Property : text");
                    string? content = reader.GetString();
                    if (!string.IsNullOrEmpty(content)) //temponary
                    {
                        motd.content = content;
                        motd.TextFormatting.Add(TextFormatEnum.Noraml);
                        contents.Add(motd);
                    }
                    continue;
                }
                //Execute complex json motd deserialize
                //TODO : simplify,this code too complex
                else if (propertyName == "extra")
                {
                    //Array read
                    //reader.Read();//Execute skip StartArray
                    if (reader.TokenType == JsonTokenType.StartArray)
                    {
                        while (reader.TokenType != JsonTokenType.EndArray)
                        {
                            reader.Read();
                            if(reader.TokenType == JsonTokenType.StartObject) reader.Read(); //Execute skip StartObject

                            if (reader.TokenType == JsonTokenType.EndObject)
                            {
                                Debug.WriteLine($"MOTD, COLOR : {motd.color ?? "null"}, Content : {motd.content ?? "null"}");
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
                                    //simplify
                                    string color = reader.GetString() ?? "";
                                    MotdData.ColorDict.TryGetValue(color, out color);
                                    if (string.IsNullOrEmpty(color))  color = reader.GetString();
                                    
                                    motd.color = color;
                                    break;
                                case "bold":
                                    if (reader.GetBoolean()) motd.TextFormatting.Add(TextFormatEnum.Bold);
                                    break;
                                case "italic":
                                    if (reader.GetBoolean()) motd.TextFormatting.Add(TextFormatEnum.Italic);
                                    break;
                                case "text":
                                    motd.content = reader.GetString();
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
