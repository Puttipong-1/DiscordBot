using DiscordBot.Model.Response.Item;
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
    [Group("item")]
    [Description("Item commands")]
    class ItemCommand:BaseCommandModule
    {
        private readonly ItemService itemService;
        private readonly ItemEmbedService embedService;
        public ItemCommand(ItemService _itemService,ItemEmbedService _embedService)
        {
            itemService = _itemService;
            embedService = _embedService;
        }
        [Command("list"),Description("Get all items")]
        public async Task GetItemList(CommandContext ctx)
        {
            try
            {
                List<Item> items = await itemService.GetItemList();
                if (items == null && items.Count == 0)
                {
                    await ctx.RespondAsync("Items not found");
                    return;
                }
                string text = embedService.CreateItemsString(items);
                var itr = ctx.Client.GetInteractivity();
                var embed = new DiscordEmbedBuilder()
                    .WithTitle("Item list");
                var pages = itr.GeneratePagesInEmbed(text, SplitType.Line, embed);
                await itr.SendPaginatedMessageAsync(ctx.Channel, ctx.User, pages, timeoutoverride: TimeSpan.FromDays(5));
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
        [GroupCommand,Description("Get item's detail")]
        public async Task GetItemDetail(CommandContext ctx,
            [Description("Item's name")] string name)
        {
            try
            {
                ItemDetail item = await itemService.GetItemDetail(name);
                if (item == null)
                {
                    await ctx.RespondAsync("Item not found");
                    return;
                }
                DiscordEmbed embed = embedService.CreateItemDetailEmbed(item);
                await ctx.RespondAsync(embed);
            }
            catch (Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            }
        }
    }
}
