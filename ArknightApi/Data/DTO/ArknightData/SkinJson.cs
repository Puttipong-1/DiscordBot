using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.ArknightData
{
    public class BattleSkin
    {
        [JsonPropertyName("overwritePrefab")]
        public bool OverwritePrefab { get; set; }

        [JsonPropertyName("skinOrPrefabId")]
        public object SkinOrPrefabId { get; set; }
    }

    public class DisplaySkin
    {
        [JsonPropertyName("skinName")]
        public object SkinName { get; set; }

        [JsonPropertyName("colorList")]
        public List<string> ColorList { get; set; }

        [JsonPropertyName("titleList")]
        public List<string> TitleList { get; set; }

        [JsonPropertyName("modelName")]
        public string ModelName { get; set; }

        [JsonPropertyName("drawerName")]
        public string DrawerName { get; set; }

        [JsonPropertyName("skinGroupId")]
        public string SkinGroupId { get; set; }

        [JsonPropertyName("skinGroupName")]
        public string SkinGroupName { get; set; }

        [JsonPropertyName("skinGroupSortIndex")]
        public int SkinGroupSortIndex { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("dialog")]
        public object Dialog { get; set; }

        [JsonPropertyName("usage")]
        public string Usage { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("obtainApproach")]
        public string ObtainApproach { get; set; }

        [JsonPropertyName("sortId")]
        public int SortId { get; set; }

        [JsonPropertyName("displayTagId")]
        public object DisplayTagId { get; set; }

        [JsonPropertyName("getTime")]
        public int GetTime { get; set; }

        [JsonPropertyName("onYear")]
        public int OnYear { get; set; }

        [JsonPropertyName("onPeriod")]
        public int OnPeriod { get; set; }
    }

    public class SkinJson
    {
        [JsonPropertyName("skinId")]
        public string SkinId { get; set; }

        [JsonPropertyName("charId")]
        public string CharId { get; set; }

        [JsonPropertyName("tokenSkinMap")]
        public object TokenSkinMap { get; set; }

        [JsonPropertyName("illustId")]
        public string IllustId { get; set; }

        [JsonPropertyName("avatarId")]
        public string AvatarId { get; set; }

        [JsonPropertyName("portraitId")]
        public string PortraitId { get; set; }

        [JsonPropertyName("buildingId")]
        public object BuildingId { get; set; }

        [JsonPropertyName("battleSkin")]
        public BattleSkin BattleSkin { get; set; }

        [JsonPropertyName("isBuySkin")]
        public bool IsBuySkin { get; set; }

        [JsonPropertyName("displaySkin")]
        public DisplaySkin DisplaySkin { get; set; }
    }
}
