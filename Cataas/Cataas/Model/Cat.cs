using System.Text.Json.Serialization;

namespace Cataas.Model
{
    public class Cat
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }
    }
}
 