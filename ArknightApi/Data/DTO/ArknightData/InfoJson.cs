using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class Story
    {
        [JsonPropertyName("storyText")]
        public string StoryText { get; set; }

        [JsonPropertyName("unLockType")]
        public int UnLockType { get; set; }

        [JsonPropertyName("unLockParam")]
        public string UnLockParam { get; set; }

        [JsonPropertyName("unLockString")]
        public string UnLockString { get; set; }
    }

    public class StoryTextAudio
    {
        [JsonPropertyName("stories")]
        public List<Story> Stories { get; set; }

        [JsonPropertyName("storyTitle")]
        public string StoryTitle { get; set; }

        [JsonPropertyName("unLockorNot")]
        public bool UnLockorNot { get; set; }
    }

    public class CharInfo
    {
        [JsonPropertyName("charID")]
        public string CharID { get; set; }

        [JsonPropertyName("drawName")]
        public string DrawName { get; set; }

        [JsonPropertyName("infoName")]
        public string InfoName { get; set; }

        [JsonPropertyName("storyTextAudio")]
        public List<StoryTextAudio> StoryTextAudio { get; set; }
    }
}
