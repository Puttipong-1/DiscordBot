using DiscordBot.Model.Response.Recruit;
using DiscordBot.Service;
using DiscordBot.Service.Embed;
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
    [Group("recruit")]
    [Description("Recruit commands")]
    class RecruitCommand : BaseCommandModule
    {
        private readonly RecruitService recruitService;
        private readonly RecruitEmbedService embedService;
        public RecruitCommand(RecruitService _recruitService, RecruitEmbedService _embedService) {
            recruitService = _recruitService;
            embedService = _embedService;
        }
        [Command("tag"), Description("Get operator's recruit tag")]
        public async Task GetOperatorTag(CommandContext ctx,
            [Description("Operator's name")] string name)
        {
            try
            {
                OperatorTag op = await recruitService.GetOperatorTag(name);
                if (op is null)
                {
                    await ctx.RespondAsync("Operator not found");
                    return;
                }
                DiscordEmbedBuilder embed = embedService.CreateOperatorTagEmbed(op);
                await ctx.RespondAsync(embed);
            } catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("taglist"), Description("Get all recruit tags")]
        public async Task GetOperatorTag(CommandContext ctx)
        {
            try
            {
                List<string> tags = await recruitService.GetRecruitTag();
                if (tags is null && tags.Count == 0) {
                    await ctx.RespondAsync("Operator not found");
                    return;
                }
                DiscordEmbed embed = embedService.CreateRecruitTagsEmbed(tags);
                await ctx.RespondAsync(embed);
               
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [GroupCommand, Description("Get recruit operator by tags")]
        public async Task GetOperatorsByTag(CommandContext ctx,
            [Description("Recruit tags (Separate tags with commas)")] string tags)
        {
            try
            {
                Dictionary<string, List<string>> dic = await recruitService.GetOperatorsByTags(tags);
                if (dic is null && dic.Count == 0)
                {
                    await ctx.RespondAsync("Operator not found");
                    return;
                }
                List<Page> pages = embedService.CreateRecruitOperatorPages(dic);
                var itr = ctx.Client.GetInteractivity();
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));

            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"Not found.");
            }
        }
        [Command("list"),Description("Get all recruited operators")]
        public async Task GetOperatorsList(CommandContext ctx)
        {
            try
            {
                List<RecruitOperators> recruits = await recruitService.GetRecruitOperators();
                if (recruits is null && recruits.Count == 0)
                {
                    await ctx.RespondAsync("Not found.");
                    return;
                }
                string text = embedService.CreateRecruitOperators(recruits);
                var itr = ctx.Client.GetInteractivity();
                var pages = itr.GeneratePagesInEmbed(text, SplitType.Line);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));

            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }

    }
}
