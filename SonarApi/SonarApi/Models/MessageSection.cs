using Newtonsoft.Json;
using System.Collections.Generic;

namespace SonarApi.Models
{
    /// <summary>
    /// Modelo de sección de mensaje de teams
    /// </summary>
    public class MessageSection
    {
        [JsonProperty("activityTitle")]
        public string Title { get; set; }

        [JsonProperty("activitySubtitle")]
        public string Subtitle { get; set; }

        [JsonProperty("activityImage")]
        public string Image { get; set; }
        
        [JsonProperty("facts")]
        public IList<MessageFact> Facts { get; set; }
    }
}