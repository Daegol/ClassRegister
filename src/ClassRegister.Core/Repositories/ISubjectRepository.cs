using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface ISubjectRepository
    {
        Task AddSubject(Subject subject);
        Task<IEnumerable<Subject>> GetAll();
        Task RemoveSubject(Guid subjectId);
        Task UpdateSubject(Subject subject);
        Task<Subject> GetById(Guid id);
    }
}