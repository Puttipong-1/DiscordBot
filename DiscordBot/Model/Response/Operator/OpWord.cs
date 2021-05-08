using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Operator
{
    public class Word
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class OpWord
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }
        [JsonPropertyName("operatorCode")]
        public string OperatorCode { get; set; }

        [JsonPropertyName("words")]
        public List<Word> Words { get; set; }
    }
}
