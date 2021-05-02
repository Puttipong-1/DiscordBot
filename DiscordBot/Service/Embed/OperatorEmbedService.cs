﻿using System;
using System.Collections.Generic;
using System.Text;
using DiscordBot.Model.Response.Operator;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;

namespace DiscordBot.Service.Embed
{
    class OperatorEmbedService
    {
        public List<Page> CreateBaseBuffPage(BaseBuff bb)
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
    }
}