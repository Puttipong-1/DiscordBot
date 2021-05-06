using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Tip
{
    public class Tip
    {
        [JsonPropertyName("tips")]
        public List<Tips> Tips { get; set; }
        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
    public class Tips
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
