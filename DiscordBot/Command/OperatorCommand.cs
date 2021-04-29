using DiscordBot.Model.Response.Operator;
using DiscordBot.Service;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity.Enums;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Command
{
    [Group("operator"),Aliases("o")]
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
                    page += $"[{op.Id}][{op.Rarity}⭐]{op.Name}\n";
                }
                var pages=interactivity.GeneratePagesInEmbed(page,SplitType.Line);
                await interactivity.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
            
        }
    }
}
