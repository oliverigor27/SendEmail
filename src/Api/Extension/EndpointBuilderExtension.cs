using SendEmail.Api.Endpoint;

namespace SendEmail.Api.Extension;

public static class EndpointBuilderExtension
{
    public static WebApplication UseRoutes(this WebApplication app)
    {
        var builder = app.MapGroup("");
        MapSendEmailGroup(builder);
        return app;
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder builder) where TEndpoint : IEndpoint
    {
        TEndpoint.Map(builder);
        return builder;
    }

    public static void MapSendEmailGroup(IEndpointRouteBuilder builder)
    {
        builder.MapGroup("/email")
            .WithTags("Send Email Endpoint")
            .MapEndpoint<SendEmailEndpoint>();
    }
}
