using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class Cond{
        public int Phase { get; set; }
        public int lvl { get; set; }
    }
    public class BuffData
    {
        [JsonPropertyName("buffId")]
        public string BuffId { get; set; }
        [JsonPropertyName("cond")]
        public Cond Cond { get; set; }
    }
    public class BuffChar
    {
        [JsonPropertyName("buffData")]
        public List<BuffData> BuffData { get; set; }
    }
    public class CharBuff
    {
        [JsonPropertyName("charId")]
        public string CharId { get; set; }

        [JsonPropertyName("maxManpower")]
        public int MaxManpower { get; set; }

        [JsonPropertyName("buffChar")]
        public List<BuffChar> BuffChar { get; set; }
    }
    public class BaseBuff
    {
        [JsonPropertyName("buffId")]
        public string BuffId { get; set; }

        [JsonPropertyName("buffName")]
        public string BuffName { get; set; }

        [JsonPropertyName("buffIcon")]
        public string BuffIcon { get; set; }

        [JsonPropertyName("skillIcon")]
        public string SkillIcon { get; set; }

        [JsonPropertyName("sortId")]
        public int SortId { get; set; }

        [JsonPropertyName("buffColor")]
        public string BuffColor { get; set; }

        [JsonPropertyName("textColor")]
        public string TextColor { get; set; }

        [JsonPropertyName("buffCategory")]
        public string BuffCategory { get; set; }

        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
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
