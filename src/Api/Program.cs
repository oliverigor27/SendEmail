using SendEmail.Api.Extension;
using SendEmail.Application;
using SendEmail.Infrastructure;

WebApplication BuildApp(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddOpenApi();
    builder.Services.AddSwaggerServices();
    builder.Services.InfrastructureServices();
    builder.Services.ApplicationServices();
    return builder.Build();
}

void RunApp(WebApplication app)
{
    if (app.Environment.IsDevelopment())
        app.MapOpenApi();
    app.UseHttpsRedirection();
    app.UseDocumentation();
    app.UseRoutes();
    app.Run();
}

RunApp(BuildApp(args));
