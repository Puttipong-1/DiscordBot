using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class StageDropList
    {
        [JsonPropertyName("stageId")]
        public string StageId { get; set; }

        [JsonPropertyName("occPer")]
        public string OccPer { get; set; }
    }

    public class BuildingProductList
    {
        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }

        [JsonPropertyName("formulaId")]
        public string FormulaId { get; set; }
    }

    public class ItemDetail
    {
        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("iconId")]
        public string IconId { get; set; }

        [JsonPropertyName("overrideBkg")]
        public object OverrideBkg { get; set; }

        [JsonPropertyName("stackIconId")]
        public object StackIconId { get; set; }

        [JsonPropertyName("sortId")]
        public int SortId { get; set; }

        [JsonPropertyName("usage")]
        public string Usage { get; set; }

        [JsonPropertyName("obtainApproach")]
        public object ObtainApproach { get; set; }

        [JsonPropertyName("classifyType")]
        public string ClassifyType { get; set; }

        [JsonPropertyName("itemType")]
        public string ItemType { get; set; }

        [JsonPropertyName("stageDropList")]
        public List<StageDropList> StageDropList { get; set; }

        [JsonPropertyName("buildingProductList")]
        public List<BuildingProductList> BuildingProductList { get; set; }
    }
}
