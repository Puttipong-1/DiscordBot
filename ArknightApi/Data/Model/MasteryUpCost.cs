using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class MasteryUpCost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasteryUpCostId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }
        [ForeignKey("Skill")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
        public MasteryUpCost() { }
        public MasteryUpCost(DTO.ArknightData.LevelUpCost lvl,int index)
        {
            ItemId = int.Parse(lvl.Id);
            Count = lvl.Count;
            Level = index;
        }
    }
}
