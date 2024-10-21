using System.Net.Mail;
using System.Net;

public class CustomEmailService : ICustomEmailService
{
    // Other members and constructor here

    public async Task SendConfirmationEmail(string email, Guid userId, string scheme, string host)
    {
        string confirmationLink = $"{scheme}://{host}/api/Account/confirm-email?userId={userId}";
        string subject = "Xác thực email của bạn";
        string body = $"Vui lòng xác nhận email của bạn bằng cách nhấn đường link: <a href='{confirmationLink}'>Confirm Email</a>";

        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress("taiinu0126@gmail.com");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("taiinu0126@gmail.com", "sdgu ypqh ybmi cmqs");
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(mail);
            }
        }
    }
}
