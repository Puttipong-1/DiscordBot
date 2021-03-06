using ArknightApi.Data.DTO.ArknightData;
using ArknightApi.Utility;
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
        public string SkillName { get; set; }
        public string SkillCode { get; set; }
        public string SkillDescription { get; set; }
        public int SkillType { get; set; }
        public List<MasteryUpCost> MasteryUpCosts{get;set;}
        public int SpType { get; set; }
        public int ChargeTime { get; set; }
        public int MaxChargeTime { get; set; }
        public int SpCost { get; set; }
        public int MaxSpCost { get; set; }
        public int InitSp { get; set; }
        public int MaxInitSp { get; set; }
        public double Increment { get; set; }
        public double Duration { get; set; }
        public double MaxDuration { get; set; }
        public string RangeId { get; set; }
        public Skill() { }
        public Skill(DTO.ArknightData.Skill skill)
        {
            SkillCode = skill.SkillId;
            MasteryUpCosts = new List<MasteryUpCost>();
            foreach(LevelUpCostCond lvl in skill.LevelUpCostCond)
            {
                if (lvl.LevelUpCost != null)
                {
                    int index = 1;
                    foreach (LevelUpCost cost in lvl.LevelUpCost)
                    {
                        var mas = new MasteryUpCost(cost,index);
                        MasteryUpCosts.Add(mas);
                        index++;
                    }
                }           
            }
        }
        public void UpdateSkill(SkillJson skill)
        {
            Level first = skill.Levels.First();
            Level last = skill.Levels.Last();
            SkillName = first.Name;
            SkillDescription = ArknightUtil.ReplaceSkillDesc(skill.Levels.First().Description, first.Blackboard, last.Blackboard);
            SkillType = first.SkillType;
            SpType = first.SpData.SpType;
            ChargeTime = first.SpData.MaxChargeTime;
            MaxChargeTime = last.SpData.MaxChargeTime;
            SpCost = first.SpData.SpCost;
            MaxSpCost = last.SpData.SpCost;
            Increment = first.SpData.Increment;
            Duration = first.Duration;
            MaxDuration = last.Duration;
            RangeId = first.RangeId;
        }
    }
}
