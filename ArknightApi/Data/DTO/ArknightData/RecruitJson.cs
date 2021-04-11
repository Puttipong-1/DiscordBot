using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class RecruitJson
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tagList")]
        public List<string> TagList { get; set; }
    }
}
