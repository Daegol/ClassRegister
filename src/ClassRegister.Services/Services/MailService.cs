using ClassRegister.Core.Model;
using ClassRegister.Services.IServices;
using MailKit.Net.Smtp;
using MimeKit;

namespace ClassRegister.Services.Services
{
    public class MailService : IMailService
    {
        public void Send(string subject, string body, Parent parent)
        {
            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress("Mail", "edziennikxd@gmail.com"));
            message.To.Add(new MailboxAddress("User",parent.Email));
            message.Subject = subject;
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = body;
            message.Body = bodyBuilder.ToMessageBody();
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            client.Authenticate("edziennikxd@gmail.com","SuperSecret");
            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }
    }
}