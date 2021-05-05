using DiscordBot.Service;
using DiscordBot.Service.Embed;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
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
                await ctx.RespondAsync("test");
            }catch(Exception e)
            {
                await ctx.RespondAsync($"An error occurred:{e.Message}");
            } 

        }
    }
}
