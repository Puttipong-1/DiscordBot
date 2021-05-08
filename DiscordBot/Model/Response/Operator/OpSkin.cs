using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DiscordBot.Model.Response.Operator
{
    public class OpSkin
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("rarity")]
        public int Rarity { get; set; }

        [JsonPropertyName("skins")]
        public List<Skin> Skins { get; set; }
    }
    public class Skin
    {
        [JsonPropertyName("skinCode")]
        public string SkinCode { get; set; }
        [JsonPropertyName("illustId")]
        public string IllustId { get; set; }

        [JsonPropertyName("avatarId")]
        public string AvatarId { get; set; }

        [JsonPropertyName("portraitId")]
        public string PortraitId { get; set; }

        [JsonPropertyName("buildingId")]
        public object BuildingId { get; set; }

        [JsonPropertyName("artist")]
        public string Artist { get; set; }

        [JsonPropertyName("skinGroupName")]
        public string SkinGroupName { get; set; }

        [JsonPropertyName("obtainApproach")]
        public string ObtainApproach { get; set; }

        [JsonPropertyName("usage")]
        public string Usage { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; }

        [JsonPropertyName("dialog")]
        public string Dialog { get; set; }
    }
}
