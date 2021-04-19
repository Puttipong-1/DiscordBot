using ArknightApi.Data.Model;
using ArknightApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class SkillResponse
    {
        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<AllSkill> AllSkills { get; set; }
        public List<Skills> Skills { get; set; }
        public SkillResponse() { }
        public SkillResponse(Operator op)
        {
            Name = op.Name;
            Rarity = op.Rarity;
            Skills = new List<Skills>();
            AllSkills = new List<AllSkill>();
            if (op.Skills != null)
            {
                foreach (Skill s in op.Skills)
                {
                    Skills.Add(new Skills(s));
                }
            }
            if (op.AllSkillUps != null)
            {
                foreach (AllSkillUp u in op.AllSkillUps)
                {
                    AllSkills.Add(new AllSkill(u));
                }
            }
        }
    }
    public class AllSkill
    {
        public int Level { get; set; }
        public List<UpgradeCost> UpgradeCosts { get; set; }
        public AllSkill() { }
        public AllSkill(AllSkillUp all)
        {
            Level = all.Level;
            UpgradeCosts = new List<UpgradeCost>();
            if (all.AllSkillCosts != null)
            {
                foreach (AllSkillCost cost in all.AllSkillCosts)
                {
                    UpgradeCosts.Add(new UpgradeCost(cost));
                }
            }
        }
    }
    public class Skills
    {
        public string SkillName { get; set; }
        public string SkillCode { get; set; }
        public string SkillDescription { get; set; }

        public string SkillType { get; set; }
        public string SpType { get; set; }
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
        public List<MasteryLevel> MasteryLevels { get; set; }
        public Skills() { }
        public Skills(Skill skill) {
            SkillName = skill.SkillName;
            SkillCode = skill.SkillCode;
            SkillDescription = skill.SkillDescription;
            SkillType = ArknightUtil.GetSkillType(skill.SkillType);
            SpType = ArknightUtil.GetSPType(skill.SpType);
            ChargeTime = skill.ChargeTime;
            MaxChargeTime = skill.MaxChargeTime;
            SpCost = skill.SpCost;
            MaxSpCost = skill.MaxSpCost;
            InitSp = skill.InitSp;
            MaxInitSp = skill.MaxInitSp;
            Increment = skill.Increment;
            Duration = skill.Duration;
            MaxDuration = skill.MaxDuration;
            RangeId = skill.RangeId;
            MasteryLevels = new List<MasteryLevel>();
            if (skill.MasteryUpCosts != null)
            {
                var level = skill.MasteryUpCosts.GroupBy(m => m.Level).OrderBy(group=>group.Key); 
                foreach(var l in level)
                {
                    MasteryLevels.Add(new MasteryLevel(l));
                }
            }
        }
    }
    public class MasteryLevel {
        public int Level { get; set; }
        public List<UpgradeCost> UpgradeCosts {get;set;}
        public MasteryLevel() { }
        public MasteryLevel(IGrouping<int,MasteryUpCost> costs) {
            Level = costs.Key;
            UpgradeCosts = new List<UpgradeCost>();
            foreach(MasteryUpCost m in costs)
            {
                UpgradeCosts.Add(new UpgradeCost(m));
            }
        }
        
    }
    public class UpgradeCost
    {
        public int Count { get; set; }
        public string Name { get; set; }
        public UpgradeCost() { }
        public UpgradeCost(AllSkillCost all)
        {
            Count = all.Count;
            Name = all.Item.Name;
        }
        public UpgradeCost(MasteryUpCost up)
        {
            Count = up.Count;
            Name = up.Item.Name;
        }
    }
}
