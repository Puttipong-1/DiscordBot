using DiscordBot.Model.Response.Operator;
using DiscordBot.Service;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Command
{
    [Group("operator")]
    [Description("Operator commands")]
    class OperatorCommand:BaseCommandModule
    {
        private readonly OperatorService operatorService;
        public OperatorCommand(OperatorService _operatorService)
        {
            operatorService = _operatorService;
        }
        [Command("list"),Description("Display all operators")]
        public async Task GetOperatorList(CommandContext ctx)
        {
            try
            {
                List<Operator> operators = await operatorService.GetOperatorList();
                if(operators is null |   operators.Count == 0)
                {
                   await ctx.RespondAsync("No operators data!");
                }
                var interactivity = ctx.Client.GetInteractivity();
                string page = string.Empty;
                foreach(Operator op in operators)
                {
                    page += $"[#{op.Id}][{op.Rarity}⭐] - {op.Name}\n";
                }
                var embed = new DiscordEmbedBuilder()
                    .WithTitle("Operator list")
                    .WithThumbnail("https://i.imgur.com/lFd4waN.jpeg", 300, 300);
                var pages=interactivity.GeneratePagesInEmbed(page,SplitType.Line,embed);
                await interactivity.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("buff"),Description("Display operator's basebuff.")]
        public async Task GetOperatorBaseBuff(CommandContext ctx,
            [Description("Operator's name")]string name)
        {
            try
            {
                BaseBuff bb = await operatorService.GetOperatorBaseBuff(name);
                if(bb is null)
                {
                    await ctx.RespondAsync("Operator not found.");
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = new List<Page>();
                if(bb.Buffs!=null && bb.Buffs.Count>0)
                {
                    foreach(Buff b in bb.Buffs)
                    {
                        var e = new DiscordEmbedBuilder()
                            .WithTitle($"[{bb.Rarity}⭐] {bb.Name}")
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
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
    }
}
