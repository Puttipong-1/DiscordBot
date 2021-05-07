using DiscordBot.Service;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Exceptions;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using DSharpPlus.Interactivity.Enums;
using DiscordBot.Utility;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using DiscordBot.Command;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using DiscordBot.Service.Embed;

namespace DiscordBot
{
    class Program
    {
        public readonly EventId BotEventId = new EventId(42, "Bot-Ex03");
        public DiscordClient Client { get; set; }
        public InteractivityExtension Interactivity { get; set; }
        public CommandsNextExtension Commands { get; set; }
        static void Main(string[] args)
        {
            new Program().RunBotAsync().GetAwaiter().GetResult();
        }
        public async Task RunBotAsync()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false,true)
                .Build();
            Discord discord = new Discord();
            config.GetSection("Discord").Bind(discord);
            var services = ConfigureService();
            var cfg = new DiscordConfiguration
            {
                Token = discord.DiscordToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
            };
            Client = new DiscordClient(cfg);
            Client.Ready += ClientReady;
            Client.GuildAvailable += ClientGuildAvailable;
            Client.ClientErrored += ClientErrored;
            Client.UseInteractivity(new InteractivityConfiguration
            {
                PaginationBehaviour = PaginationBehaviour.Ignore,
                Timeout = TimeSpan.FromMinutes(5)
            });
                var ccfg = new CommandsNextConfiguration
                {
                    StringPrefixes = new[] { discord.Prefix },
                    EnableDms = true,
                    EnableMentionPrefix = true,
                    Services = services
            };
            Commands = Client.UseCommandsNext(ccfg);
            Commands.CommandExecuted += CommandExecute;
            Commands.CommandErrored += CommandErrored;
            Commands.RegisterCommands<ItemCommand>();
            Commands.RegisterCommands<OperatorCommand>();
            Commands.RegisterCommands<RecruitCommand>();
            Commands.RegisterCommands<TipCommand>();
            Commands.SetHelpFormatter<HelpFormatter>();
            await Client.ConnectAsync();
            await Task.Delay(-1);
        }
        private Task ClientReady(DiscordClient sender,ReadyEventArgs e)
        {
            sender.Logger.LogInformation(BotEventId,"Client is ready to process event"); 
            return Task.CompletedTask;
        }
        private Task ClientGuildAvailable(DiscordClient sender,GuildCreateEventArgs e)
        {
            sender.Logger.LogInformation(BotEventId, $"Guild available: {e.Guild.Name}");
            return Task.CompletedTask;
        }
        private Task ClientErrored(DiscordClient sender,ClientErrorEventArgs e)
        {
            sender.Logger.LogInformation(BotEventId,"{e.Context.User.Username} successfully executed '{e.Command.QualifiedName}'");
            return Task.CompletedTask;
        }
        private Task CommandExecute(CommandsNextExtension sender,CommandExecutionEventArgs e)
        {
            e.Context.Client.Logger.LogInformation(BotEventId, $"{e.Context.User.Username} successfully executed '{e.Command.QualifiedName}'");
            return Task.CompletedTask;
        }
        private async Task CommandErrored(CommandsNextExtension sender, CommandErrorEventArgs e)
        {
            e.Context.Client.Logger.LogError(BotEventId, $"{e.Context.User.Username} tried executing '{e.Command?.QualifiedName ?? "<unknown command>"}' but it errored: {e.Exception.GetType()}: {e.Exception.Message ?? "<no message>"}", DateTime.Now);
            Console.WriteLine("error type:   " + e.Exception.GetType());
            if (e.Exception is ChecksFailedException ex)
            {
                var emoji = DiscordEmoji.FromName(e.Context.Client, ":no_entry:");
                var embed = new DiscordEmbedBuilder
                {
                    Title = "Access denied",
                    Description = $"{emoji}",
                    Color = new DiscordColor(0xFF0000)
                };
                await e.Context.RespondAsync(embed);
            }
        }
        public ServiceProvider ConfigureService()
        {
           return new ServiceCollection()
            .AddSingleton<HttpClient>()
            .AddSingleton<ApiService>()
            .AddSingleton<ItemService>()
            .AddSingleton<OperatorService>()
            .AddSingleton<RecruitService>()
            .AddSingleton<TipService>()
            .AddSingleton<ItemEmbedService>()
            .AddSingleton<OperatorEmbedService>()
            .AddSingleton<RecruitEmbedService>()
            .AddSingleton<TipEmbedService>()
            .BuildServiceProvider();
        }
    }
}
