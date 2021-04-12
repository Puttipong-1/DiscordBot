using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class AllSkillUp
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AllSkillId { get; set; }
        public List<AllSkillCost> AllSkillCosts { get; set; }
        [ForeignKey("Operator")]
        public int OperatorId { get; set; }
        public int Level { get; set; }
        public Operator Operator { get; set; }
        public AllSkillUp() { }
        public AllSkillUp(DTO.ArknightData.AllSkillLvlup allSkill,int l)
        {
            AllSkillCosts = new List<AllSkillCost>();
            Level = l;
            if(allSkill.LvlUpCost != null)
            {
                foreach (DTO.ArknightData.LvlUpCost lvl in allSkill.LvlUpCost)
                {
                    var all = new AllSkillCost(lvl);
                    AllSkillCosts.Add(all);
                }
            }
            
        }
    }
}
