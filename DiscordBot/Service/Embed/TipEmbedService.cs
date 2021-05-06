using DiscordBot.Helper;
using DiscordBot.Model.Response.Tip;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscordBot.Service.Embed
{
    class TipEmbedService
    {
        public List<Page> CreateTipEmbed(Tip tip)
        {
            List<Page> pages = new List<Page>();
            string title = TextUtil.ToTitleCase(tip.Category);
            string text=string.Empty;
            int page = 0;
            List<List<Tips>> list = tip.Tips.Select((t, i) => new { Index = i, Value = t })
                .GroupBy(t => t.Index / 6)
                .Select(t => t.Select(x => x.Value).ToList())
                .ToList();
            if (list != null && list.Any())
            {
                foreach(List<Tips> x in list)
                {
                    page++;
                   foreach(Tips z in x)
                    {
                        if (!string.IsNullOrWhiteSpace(z.Title)) text += $"{Formatter.Bold(z.Title)+':'} ";
                        text += $"{z.Description},\n";
                    }
                    text = text.Substring(0, text.Length - 2);
                    DiscordEmbed embed = new DiscordEmbedBuilder()
                        .WithTitle($"{title} Tips - {page}")
                        .WithDescription(text)
                        .Build();
                    pages.Add(new Page { Embed = embed });
                    text = string.Empty;
                }
            }
           return pages;
        }
        public List<Page> CreateAllTipEmbed(Dictionary<string,List<TipDetail>> tips)
        {
            List<Page> pages = new List<Page>();
            foreach (var key in tips)
            {
                List<List<TipDetail>> list = key.Value.Select((t, i) => new { Index = i, Value = t })
                    .GroupBy(t => t.Index / 6)
                    .Select(t => t.Select(x => x.Value).ToList())
                    .ToList();
                int count = 1;
                string title = TextUtil.ToTitleCase(key.Key);
                string text = string.Empty;
                if (list != null && list.Count > 0)
                {
                    foreach (List<TipDetail> x in list)
                    {
                        foreach(TipDetail y in x)
                        {
                            if (!string.IsNullOrWhiteSpace(y.Title)) text += $"{Formatter.Bold(y.Title) + ':'} ";
                            text += $"{y.TipDesc},\n";
                        }
                        text = text.Substring(0, text.Length - 2);
                        DiscordEmbed embed = new DiscordEmbedBuilder()
                        .WithTitle($"{title} Tips - {count}")
                        .WithDescription(text)
                        .Build();
                        pages.Add(new Page { Embed = embed });
                        count++;
                        text = string.Empty;
                    }
                }
            }
            return pages;
        }
    }
}
