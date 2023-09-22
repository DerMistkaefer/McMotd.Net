using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace McMotdParser.Deserializer
{
    public class JsonDeserializer<T> : JsonConverter<Dictionary<string,T>> where T : class
    {

        public override Dictionary<string, T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            if(reader.TokenType is not JsonTokenType.StartObject)
            {
                // 이상한 문제 
                reader.GetString();
            }
            return null;
        }

        public override bool CanConvert(Type typeToConvert)
        {
            throw new NotImplementedException();
        }


        public override void Write(Utf8JsonWriter writer, Dictionary<string, T> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
