using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> Get();
        Task<Student> GetById(Guid id);
        Task<Student> GetByEmail(string email);
        Task<Student> GetByPesel(string pesel);
        Task AddStudent(Student student);
        Task DeleteStudent(string pesel);
        Task UpdateStudent(Student student);
    }
}