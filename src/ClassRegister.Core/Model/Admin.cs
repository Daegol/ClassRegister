using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Core.Model
{
    public class Admin : User
    {
        public Admin(Guid id, string role, string firstName, byte[] passwordHash, byte[] passwordSalt,
            string lastName, string email, string phoneNumber, string pesel, string postCode, string city,
            string street, string houseNumber) : base(id, role, firstName, passwordHash, passwordSalt, lastName, email,
            phoneNumber, pesel, postCode, city, street, houseNumber)
        {
        }
    }
}