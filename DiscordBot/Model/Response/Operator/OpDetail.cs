using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Operator
{
    public class OpDetail
    {
        [JsonPropertyName("operatorCode")]
        public string OperatorCode { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("team")]
        public string Team { get; set; }

        [JsonPropertyName("displayNumber")]
        public string DisplayNumber { get; set; }

        [JsonPropertyName("position")]
        public string Position { get; set; }

        [JsonPropertyName("displayLogo")]
        public string DisplayLogo { get; set; }

        [JsonPropertyName("itemUsage")]
        public string ItemUsage { get; set; }

        [JsonPropertyName("itemDesc")]
        public string ItemDesc { get; set; }

        [JsonPropertyName("itemObtainApproach")]
        public string ItemObtainApproach { get; set; }

        [JsonPropertyName("isNotObtainable")]
        public bool IsNotObtainable { get; set; }

        [JsonPropertyName("tagList")]
        public string TagList { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("profession")]
        public string Profession { get; set; }

        [JsonPropertyName("trait")]
        public object Trait { get; set; }

        [JsonPropertyName("cv")]
        public string Cv { get; set; }

        [JsonPropertyName("elites")]
        public List<Elite> Elites { get; set; }

        [JsonPropertyName("potentials")]
        public List<Potential> Potentials { get; set; }

        [JsonPropertyName("talents")]
        public List<Talent> Talents { get; set; }
        public class EliteCost
        {
            [JsonPropertyName("itemName")]
            public string ItemName { get; set; }

            [JsonPropertyName("count")]
            public int Count { get; set; }
        }

        public class Elite
        {
            [JsonPropertyName("rangeId")]
            public string RangeId { get; set; }

            [JsonPropertyName("maxLevel")]
            public int MaxLevel { get; set; }

            [JsonPropertyName("hp")]
            public int Hp { get; set; }

            [JsonPropertyName("maxHp")]
            public int MaxHp { get; set; }

            [JsonPropertyName("atk")]
            public int Atk { get; set; }

            [JsonPropertyName("maxAtk")]
            public int MaxAtk { get; set; }

            [JsonPropertyName("def")]
            public int Def { get; set; }

            [JsonPropertyName("maxDef")]
            public int MaxDef { get; set; }

            [JsonPropertyName("magicResistance")]
            public int MagicResistance { get; set; }

            [JsonPropertyName("cost")]
            public int Cost { get; set; }

            [JsonPropertyName("blockCnt")]
            public int BlockCnt { get; set; }

            [JsonPropertyName("respawnTime")]
            public int RespawnTime { get; set; }

            [JsonPropertyName("eliteCosts")]
            public List<EliteCost> EliteCosts { get; set; }
        }
        public class Potential
        {
            [JsonPropertyName("desc")]
            public string Desc { get; set; }
        }

        public class Talent
        {
            [JsonPropertyName("phase")]
            public int Phase { get; set; }

            [JsonPropertyName("requirePotential")]
            public int RequirePotential { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("description")]
            public string Description { get; set; }
        }
    }
}
