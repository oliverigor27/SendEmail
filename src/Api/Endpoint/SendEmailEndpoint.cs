using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SendEmail.Api.Model;
using SendEmail.Application.Contracts;
using SendEmail.Application.DTO;

namespace SendEmail.Api.Endpoint;

public class SendEmailEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder builder)
    {
        builder.MapPost("/send", HandlerAsync)
            .WithSummary("Endpoint responsible to send a email using SMTP Client of MailKit.")
            .Produces<SendEmailRequest>()
            .Produces(StatusCodes.Status200OK);
    }

    private static async Task<Ok<string>> HandlerAsync(IEmailService service, [FromBody] SendEmailRequest request)
    {
        await service.Send(new SendEmailDTO{
             Recipient = request.Recipient,
             Subject = request.Subject,
             Body = request.Body
        });
        return TypedResults.Ok("Email enviado com sucesso!");
    }
}
