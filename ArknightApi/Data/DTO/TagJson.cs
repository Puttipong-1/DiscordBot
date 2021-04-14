using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO
{
    public class TagJson
    {
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }
    }
}
