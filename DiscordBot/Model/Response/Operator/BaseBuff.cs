using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Operator
{
    public class BaseBuff
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("buffs")]
        public List<Buff> Buffs { get; set; }
    }
    public class Buff
    {
        [JsonPropertyName("buffName")]
        public string BuffName { get; set; }

        [JsonPropertyName("buffIcon")]
        public string BuffIcon { get; set; }

        [JsonPropertyName("skillIcon")]
        public string SkillIcon { get; set; }

        [JsonPropertyName("buffCategory")]
        public string BuffCategory { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("roomType")]
        public string RoomType { get; set; }
        [JsonPropertyName("phase")]
        public int Phase { get; set; }
        [JsonPropertyName("lvl")]
        public int Lvl { get; set; }
    }
}
