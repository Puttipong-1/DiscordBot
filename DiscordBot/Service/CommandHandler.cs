using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class CommandHandler
    {
        private readonly DiscordSocketClient client;
        private readonly CommandService commandService;
        private readonly IServiceProvider services;
        public CommandHandler(DiscordSocketClient _client,CommandService _commandService,IServiceProvider _service)
        {
            client = _client;
            commandService = _commandService;
            services = _service;
            commandService.CommandExecuted += CommandExecutedAsync;
            client.MessageReceived += HandleCommandAsync;
        }
        public async Task InstallCommand()
        {
            await commandService.AddModulesAsync(Assembly.GetEntryAssembly(), services);
        }
        private async Task HandleCommandAsync(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            if (message is null) return;
            int argPos = 0;
            if(!(message.HasCharPrefix('!',ref argPos)||
                message.HasMentionPrefix(client.CurrentUser,ref argPos))||
                message.Author.IsBot) return;
            var context = new SocketCommandContext(client, message);
            await commandService.ExecuteAsync(context, argPos,services);
        }
        public async Task CommandExecutedAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            if (!command.IsSpecified) return;
            if (result.IsSuccess) return;
            await context.Channel.SendMessageAsync($"error: {result}");
        }
    }
}
