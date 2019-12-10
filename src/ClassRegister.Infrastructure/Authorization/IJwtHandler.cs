using System;
using ClassRegister.Core.Model;

namespace ClassRegister.Infrastructure.Authorization
{
    public interface IJwtHandler
    {
        string CreateToken(User user);
        bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt);
    }
}