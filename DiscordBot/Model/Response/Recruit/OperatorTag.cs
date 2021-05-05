using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Recruit
{
    public class OperatorTag
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("operatorCode")]
        public string OperatorCode { get; set; }
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
