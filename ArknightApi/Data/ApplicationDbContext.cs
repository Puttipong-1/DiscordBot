using ArknightApi.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArknightApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<AllSkillCost> AllSkillCosts { get; set; }
        public DbSet<AllSkillUp> AllSkillUps { get; set; }
        public DbSet<BaseBuff> BaseBuffs { get; set; }
        public DbSet<CharInfo> CharInfos { get; set; }
        public DbSet<CharWord> CharWords { get; set; }
        public DbSet<Elite> Elites { get; set; }
        public DbSet<EvolveCost> EvolveCosts { get; set; }
        public DbSet<Formula> Formulas { get; set; }
        public DbSet<FormulaCost> FormulaCosts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MasteryUpCost> MasteryUpCosts { get;set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Potential> Potentials { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Talent> Talents { get; set; }
        public DbSet<Tip> Tips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllSkillCost>().ToTable("AllSkillCost").HasKey(a => a.LevelCostId);
            modelBuilder.Entity<AllSkillUp>().ToTable("AllSkillUp").HasKey(a => a.AllSkillId);
            modelBuilder.Entity<BaseBuff>().ToTable("BaseBuff").HasKey(b => b.BaseBuffId);
            modelBuilder.Entity<CharInfo>().ToTable("CharInfo").HasKey(c => c.CharInfoId);
            modelBuilder.Entity<CharWord>().ToTable("CharWord").HasKey(c => c.CharWordId);
            modelBuilder.Entity<Elite>().ToTable("Elite").HasKey(e => e.EliteId);
            modelBuilder.Entity<EvolveCost>().ToTable("EvolveCost").HasKey(e => e.EvolveCostId);
            modelBuilder.Entity<Formula>().ToTable("Formula").HasKey(f => f.FormulaId); 
            modelBuilder.Entity<FormulaCost>().ToTable("FormulaCost").HasKey(f => new {f.ItemId,f.FormulaCostId });
            modelBuilder.Entity<Item>().ToTable("Item").HasKey(i => i.ItemId);
            modelBuilder.Entity<MasteryUpCost>().ToTable("MasteryUpCost").HasKey(m => m.MasteryUpCostId);
            modelBuilder.Entity<Operator>().Property(o => o.OperatorId).ValueGeneratedNever();
            modelBuilder.Entity<Operator>().ToTable("Operator").HasKey(o => o.OperatorId);
            modelBuilder.Entity<Potential>().ToTable("Potential").HasKey(p=>p.PotentialId);
            modelBuilder.Entity<Skill>().ToTable("Skill").HasKey(s=>s.SkillId);
            modelBuilder.Entity<Skin>().ToTable("Skin").HasKey(s => s.SkinId);
            modelBuilder.Entity<Talent>().ToTable("Talent").HasKey(t => t.TalentId);
            modelBuilder.Entity<Tip>().ToTable("Tip").HasKey(t => t.TipId);
        }
    }
}
