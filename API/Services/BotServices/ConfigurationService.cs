using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace API.Services.BotServices
{
    public class BotConfiguration
    {
        public string Token { get; set; }
        public string Host { get; set; }
    }

    public class ConfigurationService : IHostedService
    {
        private readonly IServiceProvider services;
        private readonly BotConfiguration configuration;

        public ConfigurationService(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            services = serviceProvider;
            this.configuration = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = services.CreateScope();
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

            var webhook = $"{configuration.Host}/bot";
            await botClient.SetWebhookAsync(url: webhook, allowedUpdates: Array.Empty<UpdateType>(),
                                            cancellationToken: cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            using var scope = services.CreateScope();
            var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();
            await botClient.DeleteWebhookAsync(cancellationToken: cancellationToken);
        }
    }
}