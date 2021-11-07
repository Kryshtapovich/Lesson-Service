using API.Services.BotServices;
using Domain.Repositories.StudentRepository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace API.Extensions
{
    public static class BotServicesExtensions
    {
        public static IServiceCollection AddBotServices(this IServiceCollection services, IConfiguration configuration)
        {
            var botConfiguration = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();

            services.AddHostedService<BotConfigurationService>();

            services.AddHttpClient("tgwebhook")
                .AddTypedClient<ITelegramBotClient>(client => new TelegramBotClient(botConfiguration.Token, client));

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<BotService>();

            return services;
        }
    }
}