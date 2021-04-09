using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class SpData
    {
        [JsonPropertyName("spType")]
        public int SpType { get; set; }

        [JsonPropertyName("levelUpCost")]
        public object LevelUpCost { get; set; }

        [JsonPropertyName("maxChargeTime")]
        public int MaxChargeTime { get; set; }

        [JsonPropertyName("spCost")]
        public int SpCost { get; set; }

        [JsonPropertyName("initSp")]
        public int InitSp { get; set; }

        [JsonPropertyName("increment")]
        public double Increment { get; set; }
    }

    public class BB
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }
    }

    public class Level
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rangeId")]
        public string RangeId { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("skillType")]
        public int SkillType { get; set; }

        [JsonPropertyName("spData")]
        public SpData SpData { get; set; }

        [JsonPropertyName("prefabId")]
        public string PrefabId { get; set; }

        [JsonPropertyName("duration")]
        public double Duration { get; set; }

        [JsonPropertyName("blackboard")]
        public List<BB> Blackboard { get; set; }
    }

    public class SkillJson
    {
        [JsonPropertyName("skillId")]
        public string SkillId { get; set; }

        [JsonPropertyName("iconId")]
        public object IconId { get; set; }

        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("levels")]
        public List<Level> Levels { get; set; }
    }
}
