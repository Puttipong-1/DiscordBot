using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Module
{
    [Group("Operator")]
    class OperatorModule:ModuleBase<SocketCommandContext>
    {
        [Command("list")]
        [Summary("Get all operators.")]
        public async Task GetOperatorList()
        {
            await Context.Channel.SendMessageAsync();
        }
        
    }
}
