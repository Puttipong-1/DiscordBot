using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Item
{
    class ItemDetail
    {

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("itemId")]
        public int ItemId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iconId")]
        public string IconId { get; set; }

        [JsonPropertyName("usage")]
        public string Usage { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("formulaDetails")]
        public List<FormulaDetail> FormulaDetails { get; set; }

        [JsonPropertyName("stageDrops")]
        public List<StageDrop> StageDrops { get; set; }
    }
    public class FormulaDetail
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class StageDrop
    {
        [JsonPropertyName("stageId")]
        public string StageId { get; set; }

        [JsonPropertyName("stageName")]
        public string StageName { get; set; }

        [JsonPropertyName("dropType")]
        public string DropType { get; set; }

        [JsonPropertyName("dropPercent")]
        public int DropPercent { get; set; }
    }

}
