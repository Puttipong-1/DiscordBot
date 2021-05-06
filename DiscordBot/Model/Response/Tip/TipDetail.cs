using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Tip
{
    class TipDetail
    {
        [JsonPropertyName("tipId")]
        public int TipId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("tipDesc")]
        public string TipDesc { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }
}
