using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class Tip
    {
        [JsonPropertyName("tip")]
        public string TipDesc { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }
    }

    public class WorldViewTip
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("backgroundPicId")]
        public string BackgroundPicId { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }
    }

    public class RootTip
    {
        [JsonPropertyName("tips")]
        public List<Tip> Tips { get; set; }

        [JsonPropertyName("worldViewTips")]
        public List<WorldViewTip> WorldViewTips { get; set; }
    }

}
