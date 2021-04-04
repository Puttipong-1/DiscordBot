using ArknightApi.Data.DTO.ArknightData;
using ArknightApi.Utility;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArknightApi.Data.Model
{
    public class Operator
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatorId { get; set; }
        public string OperatorCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string DisplayNumber { get; set; }
        public string Position { get; set; }
        public string TagList { get; set; }
        public string DisplayLogo { get; set; }
        public string ItemUsage { get; set; }
        public string ItemDesc { get; set; }
        public string ItemObtainApproach { get; set; }
        public bool IsNotObtainable { get; set; }
        public int Rarity { get; set; }
        public string Profession { get; set; }
        public string Trait { get; set; }
        public string CV { get; set; }
        public string Artist { get; set; }
        public List<Elite> Elites{get;set;}
        public List<Skill> Skills { get; set; }
        public List<Talent> Talents { get; set; }
        public List<AllSkillUp> AllSkillUps { get; set; }
        public List<CharInfo> CharInfos { get; set; }
        public List<BaseBuff> BaseBuffs { get; set; }
        public Operator() { }
        public Operator(string key,Character character)
        {
            OperatorId = ArknightUtil.GetId(key);
            OperatorCode = key;
            Name = character.Name;
            Description = ArknightUtil.RemoveBrackets(character.Description);
            Team = ArknightUtil.GetTeam(character.Team);
            DisplayNumber = character.DisplayNumber;
            TagList = ArknightUtil.JoinListTag(character.TagList);
            Position = character.Position;
            DisplayLogo = character.DisplayLogo;
            ItemUsage = character.ItemUsage;
            ItemDesc = character.ItemDesc;
            ItemObtainApproach = character.ItemObtainApproach;
            IsNotObtainable = character.IsNotObtainable;
            Rarity = ArknightUtil.CalculateRarity(character.Rarity);
            Profession = character.Profession;
            if(character.Trait!=null)
                Trait = ArknightUtil.RemoveBrackets(character.Trait.OverrideDescription);
            Elites = new List<Elite>();
            foreach(Phase p in character.Phases)
            {
                Elite e = new Elite(p,OperatorId);
                Elites.Add(e);
            }
            Skills = new List<Skill>();
            foreach(DTO.ArknightData.Skill s in character.Skills)
            {
                var skill = new Skill(s,OperatorId);
                Skills.Add(skill);
            }
            Talents = new List<Talent>();
            if (character.Talents != null)
            {
                foreach (DTO.ArknightData.Talent t in character.Talents)
                {
                    if (t.Candidates != null)
                    {
                        foreach (DTO.ArknightData.Candidate c in t.Candidates)
                        {
                            var talent = new Talent(c,OperatorId);
                            Talents.Add(talent);
                        }
                    }
                }
            }
            AllSkillUps = new List<AllSkillUp>();
            if (character.AllSkillLvlup != null)
            {
                foreach (DTO.ArknightData.AllSkillLvlup all in character.AllSkillLvlup)
                {
                    var allSkill = new AllSkillUp(OperatorId, all);
                    AllSkillUps.Add(allSkill);
                }
            }

       }
    }
}
