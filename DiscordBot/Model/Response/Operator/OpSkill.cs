using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Operator
{
    public class OpSkill
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("allSkills")]
        public List<AllSkill> AllSkills { get; set; }

        [JsonPropertyName("skills")]
        public List<Skill> Skills { get; set; }
    }
    public class UpgradeCost
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class AllSkill
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("upgradeCosts")]
        public List<UpgradeCost> UpgradeCosts { get; set; }
    }

    public class MasteryLevel
    {
        [JsonPropertyName("level")]
        public int Level { get; set; }

        [JsonPropertyName("upgradeCosts")]
        public List<UpgradeCost> UpgradeCosts { get; set; }
    }

    public class Skill
    {
        [JsonPropertyName("skillName")]
        public string SkillName { get; set; }

        [JsonPropertyName("skillCode")]
        public string SkillCode { get; set; }

        [JsonPropertyName("skillDescription")]
        public string SkillDescription { get; set; }

        [JsonPropertyName("skillType")]
        public string SkillType { get; set; }

        [JsonPropertyName("spType")]
        public string SpType { get; set; }

        [JsonPropertyName("chargeTime")]
        public int ChargeTime { get; set; }

        [JsonPropertyName("maxChargeTime")]
        public int MaxChargeTime { get; set; }

        [JsonPropertyName("spCost")]
        public int SpCost { get; set; }

        [JsonPropertyName("maxSpCost")]
        public int MaxSpCost { get; set; }

        [JsonPropertyName("initSp")]
        public int InitSp { get; set; }

        [JsonPropertyName("maxInitSp")]
        public int MaxInitSp { get; set; }

        [JsonPropertyName("increment")]
        public int Increment { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("maxDuration")]
        public int MaxDuration { get; set; }

        [JsonPropertyName("rangeId")]
        public string RangeId { get; set; }

        [JsonPropertyName("masteryLevels")]
        public List<MasteryLevel> MasteryLevels { get; set; }
    }
}
