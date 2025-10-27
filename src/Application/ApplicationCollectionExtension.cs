using Microsoft.Extensions.DependencyInjection;
using SendEmail.Application.Contracts;
using SendEmail.Application.Service;

namespace SendEmail.Application;

public static class ApplicationCollectionExtension
{
    public static IServiceCollection ApplicationServices(this IServiceCollection services)
    {
        return services.AddScoped<IEmailService, EmailService>();
    }
}
