using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<AdminDto>> GetAdmins();

        Task DeleteAdmin(string pesel);
        Task UpdateAdmin(UpdateAdminDto adminDto);
    }
}