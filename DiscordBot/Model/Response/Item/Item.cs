using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Item
{
    class Item
    {
        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
