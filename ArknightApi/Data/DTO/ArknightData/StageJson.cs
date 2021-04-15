using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class StageJson
    {
        [JsonPropertyName("stageType")]
        public string StageType { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("stageDropInfo")]
        public StageDropInfo StageDropInfo { get; set; }
    }
    public class DisplayReward
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("dropType")]
        public int DropType { get; set; }
    }

    public class DisplayDetailReward
    {
        [JsonPropertyName("occPercent")]
        public int OccPercent { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("dropType")]
        public int DropType { get; set; }
    }

    public class StageDropInfo
    {
        [JsonPropertyName("displayRewards")]
        public List<DisplayReward> DisplayRewards { get; set; }

        [JsonPropertyName("displayDetailRewards")]
        public List<DisplayDetailReward> DisplayDetailRewards { get; set; }
    }
}
