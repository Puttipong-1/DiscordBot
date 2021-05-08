using ArknightApi.Data.Model;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class SkinResponse
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<Skins> Skins { get; set; }
        public SkinResponse(Operator op)
        {
            Name = op.Name;
            Rarity = op.Rarity;
            Skins = new List<Skins>();
            if(op.Skins!=null && op.Skins.Any())
            {
                foreach(Skin s in op.Skins)
                {
                    Skins.Add(new Skins(s));
                }
            }
        }
    }
    public class Skins
    {
        public string SkinCode { get; set; }
        public string IllustId { get; set; }
        public string AvatarId { get; set; }
        public string PortraitId { get; set; }
        public string BuildingId { get; set; }
        public string Artist { get; set; }
        public string SkinGroupName { get; set; }
        public string ObtainApproach { get; set; }
        public string Usage { get; set; }
        public string Desc { get; set; }
        public string Content { get; set; }
        public string DisplayName { get; set; }
        public string Dialog { get; set; }
        public Skins(Skin s)
        {
            SkinCode = s.SkinCode;
            IllustId = s.IllustId;
            AvatarId = s.AvatarId;
            PortraitId = s.PortraitId;
            BuildingId = s.BuildingId;
            Artist = s.Artist;
            SkinGroupName = s.SkinGroupName;
            ObtainApproach = s.ObtainApproach;
            Usage = s.Usage;
            Desc = s.Desc;
            Content = s.Content;
            DisplayName = s.DisplayName;
            Dialog = s.Dialog;
        }
    }

}
