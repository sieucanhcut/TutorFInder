public interface ICustomEmailService
{
    Task SendConfirmationEmail(string email, Guid userId, string scheme, string host);
}
