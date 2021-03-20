using System;
using Newtonsoft.Json;

namespace SwiftCode.Models
{
    public class Images
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("url")]
        public string ImageUrl { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }
}
