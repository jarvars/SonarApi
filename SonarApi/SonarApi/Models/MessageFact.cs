using Newtonsoft.Json;

namespace SonarApi.Models
{
    /// <summary>
    /// Modelo de datos del mensaje de Teams 
    /// </summary>
    public class MessageFact
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}