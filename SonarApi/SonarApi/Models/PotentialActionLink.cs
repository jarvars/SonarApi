using Newtonsoft.Json;

namespace SonarApi.Models
{
    /// <summary>
    /// Modelo de acciones con enlaces en mensaje de Teams
    /// </summary>
    public class PotentialActionLink
    {
        private string name;

        [JsonProperty("os")]
        public string Type
        {
            get
            {
                return name ?? "default";
            }
            set
            {
                name = value;
            }
        }

        [JsonProperty("uri")]
        public string Value { get; set; }
    }
}