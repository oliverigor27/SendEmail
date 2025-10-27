using Microsoft.Extensions.DependencyInjection;
using SendEmail.Infrastructure.Contracts;
using SendEmail.Infrastructure.Email;

namespace SendEmail.Infrastructure;

public static class InfrastructureCollectionExtension
{
    public static IServiceCollection InfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ISendEmailService, SendEmailService>();
        return services;
    }
}
