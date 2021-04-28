using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Request
{
    public class Tag
    {
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
