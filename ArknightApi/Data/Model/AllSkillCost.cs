using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class AllSkillCost
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelCostId { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int Count { get; set; }
        [ForeignKey("AllSkill")]
        public int AllSkillId { get; set; }
        public AllSkillUp AllSkill { get; set; }
        public AllSkillCost() { }
        public AllSkillCost(DTO.ArknightData.LvlUpCost lvl)
        {
            ItemId = int.Parse(lvl.Id);
            Count = lvl.Count;
        }
    }
}
