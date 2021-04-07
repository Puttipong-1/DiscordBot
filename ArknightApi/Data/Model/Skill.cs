using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.Model
{
    public class Skill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        public int OperatorId { get; set; }
        public Operator Operator { get; set; }
        public string SkillCode { get; set; }
        public string SkillDescription { get; set; }
        public List<MasteryUpCost> MasteryUpCosts{get;set;}
        public Skill() { }
        public Skill(DTO.ArknightData.Skill skill)
        {
            SkillCode = skill.SkillId;
            MasteryUpCosts = new List<MasteryUpCost>();
            foreach(DTO.ArknightData.LevelUpCostCond lvl in skill.LevelUpCostCond)
            {
                if (lvl.LevelUpCost != null)
                {
                    foreach (DTO.ArknightData.LevelUpCost cost in lvl.LevelUpCost)
                    {
                        var mas = new MasteryUpCost(cost);
                        MasteryUpCosts.Add(mas);
                    }
                }           
            }
        }
    }
}
