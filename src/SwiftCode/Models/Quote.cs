using System;
using Newtonsoft.Json;

namespace SwiftCode.Models
{
    public class Quote
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("quote")]
        public string Message { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }
}