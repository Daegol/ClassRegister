using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface IParentRepository
    {
        Task<IEnumerable<Parent>> Get();
        Task<Parent> GetById(Guid id);
        Task<Parent> GetByEmail(string email);
        Task<Parent> GetByPesel(string pesel);
        Task AddParent(Parent parent);
        Task DeleteParent(string pesel);
        Task UpdateParent(Parent parent);
    }
}