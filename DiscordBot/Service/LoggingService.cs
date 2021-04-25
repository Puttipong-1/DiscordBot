using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.Service
{
    class LoggingService
    {
        public LoggingService(DiscordSocketClient client,CommandService commandService) {
            client.Log += LogAsync;
            commandService.Log += LogAsync;
        }
        private Task LogAsync(LogMessage message)
        {
            if(message.Exception is CommandException cmdException)
            {
                Console.WriteLine($"[Command/{message.Severity}] {cmdException.Command.Aliases.First()} failed to execute in {cmdException.Context.Channel}.");
                Console.WriteLine(cmdException);
            }
            else Console.WriteLine($"[General/{message.Severity}] {message}");
            return Task.CompletedTask;
        }
    }
}
