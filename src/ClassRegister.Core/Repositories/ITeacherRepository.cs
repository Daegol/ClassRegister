using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> Get();
        Task<Teacher> GetById(Guid id);
        Task<Teacher> GetByEmail(string email);
        Task<Teacher> GetByPesel(string pesel);
        Task AddTeacher(Teacher teacher);
        Task DeleteTeacher(string pesel);
        Task UpdateTeacher(Teacher teacher);
    }
}