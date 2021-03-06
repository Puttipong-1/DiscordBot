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
using System.Net.Http;
using DiscordBot.Service.Embed;

namespace DiscordBot.Command
{
    [Group("operator")]
    [Description("Operator commands")]
    class OperatorCommand:BaseCommandModule
    {
        private readonly OperatorService operatorService;
        private readonly OperatorEmbedService embedService;
        public OperatorCommand(OperatorService _operatorService,OperatorEmbedService _embedService)
        {
            operatorService = _operatorService;
            embedService = _embedService;
        }
        [Command("list"),Description("Display all operators")]
        public async Task GetOperatorList(CommandContext ctx)
        {
            try
            { 
                List<Operator> operators = await operatorService.GetOperatorList();
                if(operators is null | operators.Count == 0)
                {
                   await ctx.RespondAsync("No operators data!");
                   return;
                }
                var interactivity = ctx.Client.GetInteractivity();
                string page = string.Empty;
                foreach(Operator op in operators)
                {
                    page += $"[#{op.Id}][{op.Rarity}★] - {op.Name}\n";
                }
                var embed = new DiscordEmbedBuilder()
                    .WithTitle("Operator list")
                    .WithThumbnail("", 300, 300);
                var pages=interactivity.GeneratePagesInEmbed(page,SplitType.Line,embed);
                await interactivity.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("buffs"),Description("Display operator's basebuff.")]
        public async Task GetOperatorBaseBuff(CommandContext ctx,
            [Description("Operator's name")]string name)
        {
            try
            {
                BaseBuff bb = await operatorService.GetOperatorBaseBuff(name);
                if(bb is null)
                {
                    await ctx.RespondAsync("Operator not found.");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateBaseBuffPages(bb);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }catch(Exception e)
            { 
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [GroupCommand,Description("Get Operator's detail by name")]
        public async Task GetOperatorByName(CommandContext ctx,
            [Description("Operator's name")]string name)
        {
            try
            {
                OpDetail op = await operatorService.GetOperatorDetail(name);
                if (op is null) { 
                    await ctx.RespondAsync("Operator not found.");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateOpDetailPages(op,ctx.Client);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("quote"), Description("Get Operator's quote by name")]
        public async Task GetOperatorQuote(CommandContext ctx,
             [Description("Operator's name")] string name)
        {
            try
            {
                OpWord op = await operatorService.GetOperatorQuote(name);
                if (op is null)
                {
                    await ctx.RespondAsync("Operator not found.");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateOpWordPages(op);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("skills"), Description("Get Operator's skill by name")]
        public async Task GetOpeatorSkill(CommandContext ctx,[Description("Operator's name")] string name)
        {
            try
            {
                OpSkill op = await operatorService.GetOperatorSkill(name);
                if (op is null)
                {
                    await ctx.RespondAsync("Operator not found.");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateOpSkillPages(op);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("files"), Description("Get Operator's lore by name")]
        public async Task GetOpeatorFiles(CommandContext ctx, [Description("Operator's name")] string name)
        {
            try
            {
                OpProfile op = await operatorService.GetOperatorProfile(name);
                if (op is null)
                {
                    await ctx.RespondAsync("Operator not found.");
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateOpProfilePages(op);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("skins"),Description("Get operator's skin by name")]
        public async Task GetOperatorSkins(CommandContext ctx,
            [Description("Operator's name")] string name)
        {
            try
            {
                OpSkin op = await operatorService.GetOperatorSkin(name);
                if (op is null)
                {
                    await ctx.RespondAsync("Operator not found.");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateOpSkinPages(op);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }

    }
}
