using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class ExtraOutcomeGroup
    {
        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }

        [JsonPropertyName("itemCount")]
        public int ItemCount { get; set; }
    }

    public class Cost
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    public class RequireRoom
    {
        [JsonPropertyName("roomId")]
        public string RoomId { get; set; }

        [JsonPropertyName("roomLevel")]
        public int RoomLevel { get; set; }

        [JsonPropertyName("roomCount")]
        public int RoomCount { get; set; }
    }

    public class Building
    {
        [JsonPropertyName("sortId")]
        public int SortId { get; set; }

        [JsonPropertyName("formulaId")]
        public string FormulaId { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("itemId")]
        public string ItemId { get; set; }

        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("goldCost")]
        public int GoldCost { get; set; }

        [JsonPropertyName("apCost")]
        public int ApCost { get; set; }

        [JsonPropertyName("formulaType")]
        public string FormulaType { get; set; }

        [JsonPropertyName("buffType")]
        public string BuffType { get; set; }

        [JsonPropertyName("extraOutcomeRate")]
        public double ExtraOutcomeRate { get; set; }

        [JsonPropertyName("extraOutcomeGroup")]
        public List<ExtraOutcomeGroup> ExtraOutcomeGroup { get; set; }

        [JsonPropertyName("costs")]
        public List<Cost> Costs { get; set; }

        [JsonPropertyName("requireRooms")]
        public List<RequireRoom> RequireRooms { get; set; }

        [JsonPropertyName("requireStages")]
        public List<object> RequireStages { get; set; }
    }
}
