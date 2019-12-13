using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAll();
        Task AddClass(Class group);
        Task<Class> GetById(Guid? id);
        Task DeleteClass(Guid id);
        Task UpdateClass(Class grup);
    }
}