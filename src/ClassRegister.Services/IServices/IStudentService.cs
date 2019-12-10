using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetStudents();

        Task DeleteStudent(string pesel);
        Task UpdateStudent(UpdateStudentDto studentDto);
    }
}