using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface IAdminRepository
    {
        Task<IEnumerable<Admin>> Get();
        Task<Admin> GetById(Guid id);
        Task<Admin> GetByEmail(string email);
        Task<Admin> GetByPesel(string pesel);
        Task AddAdmin(Admin admin);
        Task DeleteAdmin(string pesel);
        Task UpdateAdmin(Admin admin);
    }
}