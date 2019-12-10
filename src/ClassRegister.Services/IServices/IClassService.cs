using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface IClassService
    {
        Task AddClass(ClassToAddDto group);
    }
}