using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface IClassRepository
    {
        Task AddClass(Class group);
    }
}