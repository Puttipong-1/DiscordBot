using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Recruit
{
    public class RecruitOperators
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
