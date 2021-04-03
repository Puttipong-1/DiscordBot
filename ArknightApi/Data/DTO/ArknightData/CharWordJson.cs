using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class CharWordJson
    {
        [JsonPropertyName("charWordId")]
        public string CharWordId { get; set; }

        [JsonPropertyName("charId")]
        public string CharId { get; set; }

        [JsonPropertyName("voiceId")]
        public string VoiceId { get; set; }

        [JsonPropertyName("voiceText")]
        public string VoiceText { get; set; }

        [JsonPropertyName("voiceTitle")]
        public string VoiceTitle { get; set; }

        [JsonPropertyName("voiceIndex")]
        public int VoiceIndex { get; set; }

        [JsonPropertyName("voiceType")]
        public string VoiceType { get; set; }

        [JsonPropertyName("unlockType")]
        public string UnlockType { get; set; }

        [JsonPropertyName("unlockParam")]
        public List<object> UnlockParam { get; set; }

        [JsonPropertyName("lockDescription")]
        public string LockDescription { get; set; }

        [JsonPropertyName("placeType")]
        public string PlaceType { get; set; }

        [JsonPropertyName("voiceAsset")]
        public string VoiceAsset { get; set; }
    }
}
