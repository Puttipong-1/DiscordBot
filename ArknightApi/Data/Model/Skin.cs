using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Skin
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkinId { get; set; }
        public string SkinCode{ get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public string IllustId { get; set; }
        public string AvatarId { get; set; }
        public string PortraitId { get; set; }
        public string BuildingId { get; set; }
        public string Artist { get; set; }
        public string Content { get; set; }
        public string Usage { get; set; }
        public string Desc { get; set; }
        public string SkinGroupName { get; set; }
        public string ObtainApproach { get; set; }
        public Skin() { }
        public Skin(DTO.ArknightData.SkinJson sk)
        {
            SkinCode = sk.SkinId;
            OperatorId = ArknightUtil.GetId(sk.CharId);
            IllustId = sk.IllustId;
            AvatarId = sk.AvatarId;
            PortraitId = sk.PortraitId;
            Artist = sk.DisplaySkin.DrawerName;
            SkinGroupName = sk.DisplaySkin.SkinGroupName;
            Content = sk.DisplaySkin.Content;
            Usage = sk.DisplaySkin.Usage;
            Desc = sk.DisplaySkin.Description;
            ObtainApproach = sk.DisplaySkin.ObtainApproach;
        }
    }
}
