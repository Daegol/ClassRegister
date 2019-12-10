using System;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Services.IServices
{
    public interface IAuthService
    {
        Task<string> Login(string userName, string password);

        Task Register(string role, string firstName,
            string lastName, string email, string phoneNumber, string pesel, string postCode, string city,
            string street, string houseNumber, string password);
    }
}