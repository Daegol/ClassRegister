using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface ITeacherService
    {
        Task<IEnumerable<TeacherDto>> GetTeachers();

        Task DeleteTeacher(string pesel);
        Task UpdateTeacher(UpdateTeacherDto teacherDto);
        Task<IEnumerable<TeacherToGroupDto>> GetTeachersToGroup();
    }
}