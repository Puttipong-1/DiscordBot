using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DiscordBot.Command;
using DiscordBot.Model.Response.Operator;
using DiscordBot.Utility;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using static DiscordBot.Model.Response.Operator.OpDetail;
using System.Linq;
using Microsoft.Extensions.Options;
using DiscordBot.Common;
using DSharpPlus.CommandsNext;

namespace DiscordBot.Service.Embed
{
    class OperatorEmbedService
    {
        private readonly AmazonS3 s3;
        public OperatorEmbedService(IOptions<AmazonS3> _s3)
        {
            s3 = _s3.Value;
        }
        public List<Page> CreateBaseBuffPages(BaseBuff bb)
        {
            List<Page> pages = new List<Page>();
            if (bb.Buffs != null && bb.Buffs.Count > 0)
            {
                foreach (Buff b in bb.Buffs)
                {
                    var e = new DiscordEmbedBuilder()
                       .WithTitle($"[{bb.Rarity}★] {bb.Name}")
                       .WithDescription($"{b.BuffName}")
                       .WithThumbnail($"{s3.Url}infrastructure/{b.SkillIcon}.png")
                       .AddField("Room", b.RoomType)
                       .AddField("Unlock", $"Elite {b.Phase} , Level {b.Lvl}")
                       .AddField("Description", b.Description);
                    pages.Add(new Page
                    {
                        Embed = e.Build()
                    });
                }
            }
            return pages;
        }
        public List<Page> CreateOpDetailPages(OpDetail op, DiscordClient client)
        {
            List<DiscordEmoji> emojis = new List<DiscordEmoji>
            {
                DiscordEmoji.FromGuildEmote(client, 840489819812921384),
                DiscordEmoji.FromGuildEmote(client, 840489819481440267),
                DiscordEmoji.FromGuildEmote(client, 840489819594555414),
                DiscordEmoji.FromGuildEmote(client, 840489820177563648),
                DiscordEmoji.FromGuildEmote(client, 840489820924543016)
            };
            int i = 0;
            string pot = "\u200b";
            if (op.Potentials != null && op.Potentials.Any())
            {
                foreach(var p in op.Potentials)
                {
                    pot += $"{emojis[i]} {p.Desc}\n";
                    i++;
                }
                pot = pot.Substring(0, pot.Length - 1);
            }
            Console.WriteLine($"{s3.Url}avatars/{op.OperatorCode}.png");
            List<Page> pages = new List<Page>();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                .WithTitle($"[{op.Rarity}★] {op.Name}")
                .WithDescription($"{op.ItemUsage}\n{op.ItemDesc}")
                .WithThumbnail($"{s3.Url}avatars/{op.OperatorCode}.png",60,60)
                .AddField("Detail", $"{Formatter.Bold("Affiliation:")} {TextUtil.ToTitleCase(op.Team)}\n" +
                $"{Formatter.Bold("Obtain:")} {op.ItemObtainApproach}", true)
                .AddField("\u200b",
                $"{Formatter.Bold("Tag:")} {op.TagList}\n" +
                $"{Formatter.Bold("Position:")} {TextUtil.ToTitleCase(op.Position)}\n" +
                $"{Formatter.Bold("Class:")} {TextUtil.ToTitleCase(op.Profession)}", true)
                .AddField("Range", AttackRange.GetAttackRange(op.Elites[0].RangeId), true)
                .AddField("Effect", op.Description)
                .AddField($"Level 1 → {op.Elites[0].MaxLevel}", $"{Formatter.Bold("Health:")} {op.Elites[0].Hp} → {op.Elites[0].MaxHp}\n" +
                $"{Formatter.Bold("Attack:")} {op.Elites[0].Atk} → {op.Elites[0].MaxAtk}\n" +
                $"{Formatter.Bold("Defense:")} {op.Elites[0].Def} → {op.Elites[0].MaxDef}\n" +
                $"{Formatter.Bold("Resistance:")} {op.Elites[0].MagicResistance}\n" +
                $"{Formatter.Bold("Cost:")} {op.Elites[0].Cost}\n" +
                $"{Formatter.Bold("AttackTime:")} 100\n" +
                $"{Formatter.Bold("Block:")} {op.Elites[0].BlockCnt}\n" +
                $"{Formatter.Bold("RespawnTime:")} {op.Elites[0].RespawnTime}\n", true)
                .AddField("Potentials", pot, true);
           if (op.Talents != null && op.Talents.Count > 0)
            {
                string talent = string.Empty;
                foreach(Talent t in op.Talents)
                {
                    if (t.Phase == 0)
                    {
                        talent += $"{Formatter.Bold(t.Name + ':')} {t.Description} (Lv. 1,Potential {t.RequirePotential})\n";
                    }
                }
                if (!string.IsNullOrEmpty(talent))
                {
                    talent = talent.Substring(0, talent.Count() - 1);
                    embed.AddField("Talents", talent);
                }
            }
            pages.Add(new Page
            {
                Embed = embed.Build()
            });
            if(op.Elites.ElementAtOrDefault(1)!=null) pages.Add(CreateOpDetailPage(op,1));
            if (op.Elites.ElementAtOrDefault(2) != null) pages.Add(CreateOpDetailPage(op, 2));
            return pages;
        }
        private Page CreateOpDetailPage(OpDetail op,int index)
        {
            Elite e = op.Elites[index];
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                .WithTitle($"[{op.Rarity}★] {op.Name}")
                .AddField($"Level 1 → {e.MaxLevel}",
                $"{Formatter.Bold("Health:")} {e.Hp} → {e.MaxHp}\n" +
                $"{Formatter.Bold("Attack:")} {e.Atk} → {e.MaxAtk}\n" +
                $"{Formatter.Bold("Defense:")} {e.Def} → {e.MaxDef}\n" +
                $"{Formatter.Bold("Resistance:")} {e.MagicResistance}", true)
                .AddField("\u200b", $"{Formatter.Bold("Cost:")}{e.Cost}\n" +
                $"{Formatter.Bold("Block:")} {e.BlockCnt}\n" +
                $"{Formatter.Bold("Attack Time:")} 100\n" +
                $"{Formatter.Bold("Respawn Time:")} {e.RespawnTime}\n", true)
                .AddField("Range", AttackRange.GetAttackRange(op.Elites[index].RangeId), true);
            string img = string.Empty;
            switch (index)
            {
                case 1:
                    {
                        if (op.OperatorCode.Equals("Amiya")) embed.WithThumbnail($"{s3.Url}avatars/{op.OperatorCode}_1+.png");
                        else embed.WithThumbnail($"{s3.Url}avatars/{op.OperatorCode}.png");
                        break;
                    }
                case 2:
                    {
                        embed.WithThumbnail($"{s3.Url}avatars/{op.OperatorCode}_2.png");
                        break;
                    }
            }
            if (op.Talents != null && op.Talents.Count > 0)
            {
                string talent = string.Empty;
                foreach (Talent t in op.Talents)
                {
                    if (t.Phase == index) talent += $"{Formatter.Bold(t.Name + ':')} {t.Description} (Lvl.1,Potential {t.RequirePotential})\n";
                }
                if (!string.IsNullOrEmpty(talent))
                {
                    talent = talent.Substring(0, talent.Count() - 1);
                    embed.AddField("Talents", talent);
                }
            }
            return new Page { Embed = embed.Build() };
        }
        public List<Page> CreateOpProfilePages(OpProfile op)
        {
            string img = $"{s3.Url}avatars/{op.OperatorCode}.png";
            List<Page> pages = new List<Page>();
            if (op.BasicFile != null)
            {
                DiscordEmbed embed = new DiscordEmbedBuilder()
                    .WithTitle($"[{op.Rarity}★] {op.Name} - Basic File ")
                    .WithThumbnail(img,60,60)
                    .WithDescription($"{Formatter.Bold("CV:")} {op.Cv}\n" +
                    $"{Formatter.Bold("Artist:")} {op.Artist}\n" +
                    $"{Formatter.Bold("Code Name:")} {op.BasicFile.CodeName}\n" +
                    $"{Formatter.Bold("Gender:")} {op.BasicFile.Gender}\n" +
                    $"{Formatter.Bold("Combat Experience:")} {op.BasicFile.CombatExperience}\n" +
                    $"{Formatter.Bold("Place of Birth:")} {op.BasicFile.PlaceOfBirth}\n" +
                    $"{Formatter.Bold("Date of Birth:")} {op.BasicFile.DateOfBirth}\n" +
                    $"{Formatter.Bold("Race:")} {op.BasicFile.Race}\n" +
                    $"{Formatter.Bold("Height:")} {op.BasicFile.Height}\n" +
                    $"{Formatter.Bold("Infection Status:")} {op.BasicFile.InfectionStatus}\n")
                    .Build();
                pages.Add(new Page { Embed = embed });
            }
            if (op.PhysicalExam != null)
            {
                DiscordEmbed embed = new DiscordEmbedBuilder()
                   .WithTitle($"[{op.Rarity}★] {op.Name} - Physical Exam")
                   .WithThumbnail(img, 60, 60)
                   .WithDescription($"{Formatter.Bold("Physical Strength:")} {op.PhysicalExam.PhysicalStrength}\n" +
                   $"{Formatter.Bold("Mobility:")} {op.PhysicalExam.Mobility}\n" +
                   $"{Formatter.Bold("Physical Resilience:")} {op.PhysicalExam.PhysicalResilience}\n" +
                   $"{Formatter.Bold("Tactical Acumen:")} {op.PhysicalExam.TacticalAcumen}\n" +
                   $"{Formatter.Bold("Combat Skill:")} {op.PhysicalExam.CombatSkill}\n" +
                   $"{Formatter.Bold("Originium Adaptability:")} {op.PhysicalExam.TacticalAcumen}\n")
                   .Build();
                pages.Add(new Page { Embed = embed });
            }
            if (op.Profiles != null && op.Profiles.Any())
            {
                foreach (Profile p in op.Profiles)
                {
                    DiscordEmbed embed = new DiscordEmbedBuilder()
                        .WithTitle($"[{op.Rarity}★] {op.Name} - {p.Title}")
                        .WithThumbnail(img, 60, 60)
                        .WithDescription($"{p.Text}")
                        .Build();
                    pages.Add(new Page { Embed = embed });
                }
            }
            return pages;
        }
        public List<Page> CreateOpWordPages(OpWord op)
        {
            string img = $"{s3.Url}avatars/{op.OperatorCode}.png";
            List<Page> pages = new List<Page>();
            string text = string.Empty;
            int i = 0;
            int page = 1;
            if (op.Words != null && op.Words.Any())
            {
                foreach(Word w in op.Words)
                {
                    i++;
                    text += $"{Formatter.Bold(w.Title+':')} {w.Text}\n";
                    if (i == 8)
                    {
                        var embed = new DiscordEmbedBuilder()
                            .WithTitle($"[{op.Rarity}★] {op.Name} - Quote {page}")
                            .WithThumbnail(img, 60, 60)
                            .WithDescription(text)
                            .Build();
                        pages.Add(new Page { Embed = embed });
                        text = string.Empty;
                        i = 0;
                        page++;
                    }
                }
                if (!string.IsNullOrEmpty(text))
                {
                    var embed = new DiscordEmbedBuilder()
                            .WithTitle($"[{op.Rarity}★] {op.Name} - Quote {page}")
                            .WithThumbnail(img, 60, 60)
                            .WithDescription(text)
                            .Build();
                    pages.Add(new Page { Embed = embed });
                }
            }
            return pages;
        }
        public List<Page> CreateOpSkillPages(OpSkill op)
        {
            List<Page> pages = new List<Page>();
            int i = 1;
            if (op.Skills != null && op.Skills.Any())
            {
                foreach (Skill skill in op.Skills)
                {
                    string range = AttackRange.GetAttackRange(skill.RangeId);
                    var embed = new DiscordEmbedBuilder()
                        .WithTitle($"[{op.Rarity}★] {op.Name} - {skill.SkillName}")
                        .WithThumbnail($"{s3.Url}skills/skill_icon_{skill.SkillCode}.png",60,60)
                        .AddField("Details", $"{Formatter.Bold("Recovery Type:")} {skill.SpType}\n" +
                        $"{Formatter.Bold("Sp Cost:")} {skill.SpCost} → {skill.MaxSpCost}", true)
                        .AddField("\u200b", $"{Formatter.Bold("Skill Type:")} {skill.SkillType }", true);
                    if (!string.IsNullOrWhiteSpace(range))
                    {
                        embed.AddField("Range", range, true);
                    }
                    embed.AddField("Description", $"{skill.SkillDescription}");
                    if (i == 1)
                    {
                        if (op.AllSkills != null && op.AllSkills.Any())
                        {
                            string text=string.Empty;
                            foreach (AllSkill a in op.AllSkills)
                            {
   
                                text = $"{Formatter.Bold("Lv. " +(a.Level+1)+':')}";
                                if (a.UpgradeCosts != null && a.UpgradeCosts.Any())
                                {
                                   foreach(UpgradeCost u  in a.UpgradeCosts){
                                        text += $"{u.Count}x {u.Name},";
                                    }
                                   text=text.Substring(0, text.Count() - 1);
                                }
                                text += "\n";
                            }
                            embed.AddField("Upgrade Costs", text);
                        }
                    }
                    if (skill.MasteryLevels != null && skill.MasteryLevels.Any())
                    {
                        string text = string.Empty;
                        foreach (MasteryLevel m in skill.MasteryLevels)
                        {

                            text = $"{Formatter.Bold("Mastery " + m.Level + ':')}";
                            if (m.UpgradeCosts != null && m.UpgradeCosts.Any())
                            {
                                foreach (UpgradeCost u in m.UpgradeCosts)
                                {
                                    text += $"{u.Count}x {u.Name},";
                                }
                                text = text.Substring(0, text.Count() - 1);
                            }
                            text += "\n";
                            embed.AddField("Mastery Costs", text);
                        }
                    }
                    i++;
                    pages.Add(new Page { Embed = embed.Build() });
                }
            }
            return pages;
        }
        public List<Page> CreateOpSkinPages(OpSkin op)
        {
            List<Page> pages = new List<Page>();
            if (op.Skins != null && op.Skins.Any())
            {
                foreach (Skin s in op.Skins)
                {
                    string img = s.PortraitId.Replace("#", "%23");
                    string title = $"[{op.Rarity}★] {op.Name}";
                    string f1 = $"{Formatter.Bold("Model:")} {op.Name}\n" +
                        $"{Formatter.Bold("Artist:")} {s.Artist}";
                    string f2 = $"{Formatter.Bold("Series:")} {s.SkinGroupName}";
                    string desc = "\u200b";
                    if (!string.IsNullOrWhiteSpace(s.DisplayName)) title += $" - {s.DisplayName}";
                    if (!string.IsNullOrWhiteSpace(s.ObtainApproach)) f2 +=$"\n{Formatter.Bold("Obtain Approach:")} {s.ObtainApproach}";
                    if (!string.IsNullOrWhiteSpace(s.Content)) desc = s.Content;
                    DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                        .WithTitle(title)
                        .WithThumbnail($"{s3.Url}avatars/{img}.png", 60, 60)
                        .WithDescription(desc)
                        .AddField("Detail", f1, true)
                        .AddField("\u200b", f2, true)
                        .WithImageUrl($"{s3.Url}characters/{img}.png");
                    if (!string.IsNullOrWhiteSpace(s.Usage)) embed.AddField("Usage", s.Usage);
                    if (!string.IsNullOrWhiteSpace(s.Desc)) embed.AddField("Quote", s.Desc);
                    if (!string.IsNullOrWhiteSpace(s.Dialog)) embed.AddField("Information", s.Dialog);
                    pages.Add(new Page { Embed = embed.Build() });
                }
            }
            return pages;
        }
    }
}
