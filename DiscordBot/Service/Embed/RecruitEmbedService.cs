using DiscordBot.Model.Response.Recruit;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBot.Service.Embed
{
    class RecruitEmbedService
    {
        public DiscordEmbedBuilder CreateOperatorTagEmbed(OperatorTag op)
        {
            string tags = "No tag";
            if (op.Tags != null && op.Tags.Count > 0) tags = string.Join(",", op.Tags);
            Console.WriteLine("tags" + tags);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                .WithTitle($"[{op.Rarity}★] {op.Name}")
                .WithDescription($"{Formatter.Bold("Tags")}\n{tags}")
                .AddField("test", op.OperatorCode);
            return embed;
        }
        public DiscordEmbed CreateRecruitTagsEmbed (List<string> t)
        {
            string tags = string.Join(",", t);
            DiscordEmbedBuilder embed = new DiscordEmbedBuilder()
                .WithTitle($"Recruit tag list")
                .WithDescription($"{tags}");
            return embed.Build();
        }
        public List<Page> CreateRecruitOperatorPages(Dictionary<string,List<string>> dics)
        {
            List<Page> pages = new List<Page>();
            foreach (var key in dics)
            {
                string text = string.Join('\n', key.Value);
                DiscordEmbed embed = new DiscordEmbedBuilder()
                    .WithTitle($"{key.Key}")
                    .WithDescription($"{Formatter.Bold("Operators")}\n {text}")
                    .Build();
                pages.Add(new Page { Embed = embed });
            }
            return pages;
        }
        public string CreateRecruitOperators(List<RecruitOperators> op)
        {
            string text = string.Empty;
            foreach(RecruitOperators r in op)
            {
                text +=$"[{r.Rarity}★]{r.Name}\n";
            }
            return text;
        }
    }
}
