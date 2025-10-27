using System.ComponentModel.DataAnnotations;

namespace SendEmail.Api.Model;

public class SendEmailRequest
{
    [Required]
    public string Recipient { get; set; } = string.Empty;
    
    [Required]
    public string Subject { get; set; } = string.Empty;
    
    [Required]
    public string Body { get; set; } = string.Empty;
}
