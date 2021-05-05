using DiscordBot.Model.Response.Item;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Service.Embed
{
    class ItemEmbedService
    {
        public DiscordEmbed CreateItemDetailEmbed(ItemDetail item)
        {
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                .WithTitle($"[{item.Rarity}★] {item.Name}")
                .WithDescription($"{item.Description}")
                .AddField("Usage", $"{item.Usage}");
            if (item.FormulaDetails != null && item.FormulaDetails.Count>0)
            {
                string text =string.Empty;
                foreach(FormulaDetail f in item.FormulaDetails)
                {
                    text += $"{f.Count}x {f.Name},";
                }
                text.Substring(0, text.Length - 1);
                embed.AddField("Workshop", text);
            }
            if(item.StageDrops!=null && item.StageDrops.Count > 0)
            {
                string text = string.Empty;
                foreach(StageDrop drop in item.StageDrops)
                {
                    text += $"{Formatter.Bold(drop.StageId)} - {drop.StageName} ({drop.DropType}) ({drop.DropPercent}%)\n";
                }
                text.Substring(0, text.Length - 1);
                embed.AddField("Drop Stage", text);
            }
            return embed.Build();
        }
       public string CreateItemsString(List<Item> items)
        {
            string text = string.Empty;
            foreach(Item i in items)
            {
                text += $"[#{i.ItemId}] [{i.Rarity}] - {i.Name}";
            }
            return text;
        }
    }
}
