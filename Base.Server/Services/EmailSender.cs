using Base.Shared.Models;

namespace Base.Server.Services;

public class EmailSender
{
    public async Task<Response> SendEmail(List<string> toAddresses, List<string> fromAddresses,
        List<string> ccAddresses, List<string> bccAddresses, string subject, string message)
    {
        return new()
        {
            Success = false,
            Messages = ["Not Implemented"],
        };
    }
}