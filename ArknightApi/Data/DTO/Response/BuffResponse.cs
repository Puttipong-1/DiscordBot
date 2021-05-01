using ArknightApi.Data.Model;
using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class BuffResponse
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<Buff> Buffs {get;set;}
        public BuffResponse() { }
        public BuffResponse(Operator op)
        {
            Name = op.Name;
            Rarity = op.Rarity;
            Buffs = new List<Buff>();
            if (op.BaseBuffs != null)
            {
                foreach(BaseBuff b in op.BaseBuffs)
                {
                    Buffs.Add(new Buff(b));
                }
            }
        }
    }
    public class Buff {
        public string BuffName { get; set; }
        public string BuffIcon { get; set; }
        public string SkillIcon { get; set; }
        public string BuffCategory { get; set; }
        public string Description { get; set; }
        public string RoomType { get; set; }
        public int Phase { get; set; }
        public int Lvl { get; set; }
        public Buff() { }
        public Buff(BaseBuff b)
        {
            BuffName = b.BuffName;
            BuffIcon = b.BuffIcon;
            SkillIcon = b.SkillIcon;
            BuffCategory = b.BuffCategory;
            Description = b.Description;
            RoomType = ArknightUtil.GetRoom(b.BuffIcon);
            Phase = b.Phase;
            Lvl = b.Lvl;
        }
    }

}
