using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DiscordBot.Command;
using DiscordBot.Model.Response.Operator;
using DiscordBot.Helper;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace DiscordBot.Service.Embed
{
    class OperatorEmbedService
    {
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
                       .WithThumbnail($"https://gamepress.gg/arknights/sites/arknights/files/2020-09/Bskill_train_guard3.png", 100, 100);
                    e.AddField("Room", b.RoomType);
                    e.AddField("Unlock", $"Elite {b.Phase} , Level {b.Lvl}");
                    e.AddField("Description", b.Description);
                    pages.Add(new Page
                    {
                        Embed = e.Build()
                    });
                }
            }
            return pages;
        }
        public List<Page> CreateOpDetailPages(OpDetail op)
        {
            List<Page> pages = new List<Page>();
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                .WithTitle($"[{op.Rarity}★] {op.Name}")
                .WithDescription($"{op.ItemUsage}\n{op.ItemUsage}")
                .AddField("Detail",$"{Formatter.Bold("Affiliation:")} {TextUtil.ToTitleCase(op.Team)}\n" +
                $"{Formatter.Bold("Obtain:")} {op.ItemObtainApproach}", true)
                .AddField("-",
                $"{Formatter.Bold("Tag:")} {op.TagList}\n" +
                $"{Formatter.Bold("Position:")} {TextUtil.ToTitleCase(op.Position)}\n" +
                $"{Formatter.Bold("Class:")} {TextUtil.ToTitleCase(op.Profession)}", true)
                .AddField("Range", AttackRange.GetAttackRange(op.Elites[0].RangeId), true);
            pages.Add(new Page
            {
                Embed = embed.Build()
            });
            return pages;
        }
    }
}
