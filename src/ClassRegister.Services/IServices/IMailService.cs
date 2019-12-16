using ClassRegister.Core.Model;

namespace ClassRegister.Services.IServices
{
    public interface IMailService
    {
        void Send(string subject, string body, Parent parent);
    }
}