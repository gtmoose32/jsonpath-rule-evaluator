using Newtonsoft.Json.Linq;
using System;

namespace Moosesoft.RulesEngine.Extensions
{
    public static class JTokenExtensions
    {
        public static object GetObjectAtPath(this JToken json, string jsonPath)
        {
            var token = json.SelectToken(jsonPath);
            return token.ToObject();
        }

        public static object ToObject(this JToken jtoken)
        {
            if (jtoken == null) return null;
            switch (jtoken.Type)
            {
                case JTokenType.None:
                    return null;
                case JTokenType.Object:
                    return jtoken.Value<JObject>();  //todo:  determine if something else is needed for object and array
                case JTokenType.Array:
                    return jtoken.Value<JArray>();
                case JTokenType.Constructor:
                    return null;
                case JTokenType.Property:
                    return null;
                case JTokenType.Comment:
                    return null;
                case JTokenType.Integer:
                    return jtoken.Value<int>();
                case JTokenType.Float:
                    return jtoken.Value<double>();
                case JTokenType.String:
                    return jtoken.ToString();
                case JTokenType.Boolean:
                    return jtoken.Value<bool>();
                case JTokenType.Null:
                    return null;
                case JTokenType.Undefined:
                    return null;
                case JTokenType.Date:
                    return jtoken.Value<DateTime>();
                case JTokenType.Raw:
                    return null;
                case JTokenType.Bytes:
                    return jtoken.Value<byte[]>();
                case JTokenType.Guid:
                    return jtoken.Value<Guid>();
                case JTokenType.Uri:
                    return jtoken.Value<Uri>();
                case JTokenType.TimeSpan:
                    return jtoken.Value<TimeSpan>();
                default:
                    throw new InvalidOperationException(@"Supplied JToken could not be converted.");
            }
        }        
    }
}