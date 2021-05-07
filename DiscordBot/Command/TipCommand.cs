using DiscordBot.Utility;
using DiscordBot.Model.Response.Tip;
using DiscordBot.Service;
using DiscordBot.Service.Embed;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Command
{
    [Group("tip"),Description("Tips command")]
    class TipCommand:BaseCommandModule
    {
        private readonly TipService tipService;
        private readonly TipEmbedService embedService;
        public TipCommand(TipService _tipService,TipEmbedService _embedService)
        {
            tipService = _tipService;
            embedService = _embedService;
        }
        [Command("categories"),Description("Get all tip categories")]
        public async Task GetTipCategory(CommandContext ctx)
        {
            try
            {
                List<string> categories = await tipService.GetTipCategories();
                categories.Sort();
                categories = categories.ConvertAll(x => TextUtil.ToTitleCase(x));
                string text = string.Join(',', categories);
                await ctx.RespondAsync(text);
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            } 
        }
        [GroupCommand,Description("Get tip by category")]
        public async Task GetTipByCategory(CommandContext ctx,
            [Description("Tip's category")] string category)
        {
            try
            {
                Tip tip = await tipService.GetTipByCategory(category);
                if(tip is null)
                {
                    await ctx.RespondAsync("Tips not found");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateTipEmbed(tip);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [Command("all"), Description("Get all tips")]
        public async Task GetAllTip(CommandContext ctx)
        {
            try
            {
                Dictionary<string, List<TipDetail>> dic = await tipService.GetAllTips();
                if (dic is null || dic.Count == 0)
                {
                    await ctx.RespondAsync("Tips not found");
                    return;
                }
                var itr = ctx.Client.GetInteractivity();
                List<Page> pages = embedService.CreateAllTipEmbed(dic);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromMinutes(5));
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
    }
}
