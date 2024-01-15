using System.Text.Json.Serialization;

namespace Cataas.Model
{
    public class Cat
    {
        [JsonPropertyName("_id")]
        public string _id;
    }
}
 