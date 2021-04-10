using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class GachaJson
    {
        [JsonPropertyName("tagId")]
        public int TagId { get; set; }

        [JsonPropertyName("tagName")]
        public string TagName { get; set; }

        [JsonPropertyName("tagGroup")]
        public int TagGroup { get; set; }
    }
}
