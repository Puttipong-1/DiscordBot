using ArknightApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data.DTO.Response
{
    public class OperatorResponse
    {
        public string OperatorCode { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Team { get; set; }
        public string DisplayNumber { get; set; }
        public string Position { get; set; }
        public string DisplayLogo { get; set; }
        public string ItemUsage { get; set; }
        public string ItemDesc { get; set; }
        public string ItemObtainApproach { get; set; }
        public bool IsNotObtainable { get; set; }
        public string TagList { get; set; }
        public int Rarity { get; set; }
        public string Profession { get; set; }
        public string Trait { get; set; }
        public string CV { get; set; }
        public List<Elites> Elites { get; set; }
        public List<Potentials> Potentials { get; set; }
        public List<Talents> Talents { get; set; }
        public OperatorResponse(Operator op)
        {
            OperatorCode = op.OperatorCode;
            Description = op.Description;
            Name = op.Name;
            Team = op.Team;
            DisplayNumber = op.DisplayNumber;
            Position = op.Position;
            DisplayLogo = op.DisplayLogo;
            ItemUsage = op.ItemUsage;
            ItemDesc = op.ItemDesc;
            ItemObtainApproach = op.ItemObtainApproach;
            IsNotObtainable = op.IsNotObtainable;
            Rarity = op.Rarity;
            Profession = op.Profession;
            Trait = op.Trait;
            TagList = op.TagList;
            CV = op.CV;
            Elites = new List<Elites>();
            if (op.Elites != null)
            {
                foreach(Elite e in op.Elites)
                {
                    Elites.Add(new Elites(e));
                }
            }
            Potentials = new List<Potentials>();
            if (op.Potentials != null)
            {
                foreach (Potential p in op.Potentials)
                {
                    Potentials.Add(new Potentials(p));
                }
            }
            Talents = new List<Talents>();
            if (op.Talents != null)
            {
                foreach (Talent t in op.Talents)
                {
                    Talents.Add(new Talents(t));
                }
            }
        }
    }
    public class Elites
    {
        public string RangeId { get; set; }
        public int MaxLevel { get; set; }
        public int Hp { get; set; }
        public int MaxHp { get; set; }
        public int Atk { get; set; }
        public int MaxAtk { get; set; }
        public int Def { get; set; }
        public int MaxDef { get; set; }
        public double MagicResistance { get; set; }
        public int Cost { get; set; }
        public int BlockCnt { get; set; }
        public int RespawnTime { get; set; }
        public List<EliteCost> EliteCosts { get; set; }
        public Elites(Elite e)
        {
            RangeId = e.RangeId;
            MaxLevel = e.MaxLevel;
            Hp = e.Hp;
            MaxHp = e.MaxHp;
            Def = e.Def;
            MaxDef = e.MaxDef;
            MagicResistance = e.MagicResistance;
            Cost = e.Cost;
            BlockCnt = e.BlockCnt;
            RespawnTime = e.RespawnTime;
            EliteCosts = new List<EliteCost>();
            if (e.EvolveCosts != null)
            {
                foreach(EvolveCost ec in e.EvolveCosts)
                {
                    EliteCosts.Add(new EliteCost(ec));
                }
            }
        }
    }
    public class EliteCost
    {
        public string ItemName { get; set; }
        public int Count { get; set; }
        public EliteCost(EvolveCost e)
        {
            ItemName = e.Item.Name;
            Count = e.Count;
        }
    }
    public class Potentials
    {
        public string Desc { get; set; }
        public Potentials(Potential p)
        {
            Desc = p.Desc;
        }
    }
    public class Talents
    {
        public int Phase { get; set; }
        public int RequirePotential { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Talents(Talent t)
        {
            Phase = t.Phase;
            RequirePotential = t.RequirePotential;
            Name = t.Name;
            Description = t.Description;
        }
    }

}
