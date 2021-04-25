using Discord;
using Discord.WebSocket;
using DiscordBot.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel.Design;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {

        }
        public async Task MainAsync()
        {
            using(var service = ConfigureService())
            {
                DiscordSocketConfig config = new DiscordSocketConfig { MessageCacheSize = 100 };
                DiscordSocketClient client = new DiscordSocketClient(config);
                await client.LoginAsync(TokenType.Bot, Environment.GetEnvironmentVariable("token"));
                await client.StartAsync();
                client.MessageUpdated += MessageUpdated;
                client.Ready += () =>
                {
                    Console.WriteLine("Bot is connect");
                    return Task.CompletedTask;
                };
                await Task.Delay(Timeout.Infinite);
            }
        }
        private async Task MessageUpdated(Cacheable<IMessage,ulong> before,SocketMessage after,ISocketMessageChannel channel)
        {
            var message = await before.GetOrDownloadAsync();
            Console.WriteLine($"{message}->{after}");
        }
        private ServiceProvider ConfigureService()
        {
            return new ServiceCollection()
                .AddSingleton<LoggingService>()
                .BuildServiceProvider();
        }
    }
}
