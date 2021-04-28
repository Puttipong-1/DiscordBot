using DiscordBot.Service;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace DiscordBot
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }
        
        private ServiceProvider ConfigureService()
        {
            return new ServiceCollection()
                .AddSingleton<ApiService>()
                .AddTransient<HttpClient>()
                .AddTransient<ItemService>()
                .AddTransient<OperatorService>()
                .AddTransient<PictureService>()
                .AddTransient<RecruitService>()
                .AddTransient<TipService>()
                .BuildServiceProvider();
  
        }
    }
}
