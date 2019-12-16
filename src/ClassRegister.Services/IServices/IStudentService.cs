using System;
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
        Task<IEnumerable<StudentToGroupDto>> GetStudentsToGroup();
        Task<IEnumerable<StudentToGroupDto>> GetStudentsToGroupEdit(Guid classId);
        Task<IEnumerable<StudentsToGrade>> GetStudentsToGrade(Guid classId, Guid subjectId);
        Task<IEnumerable<StudentToParentDto>> GetStudentsToParent();
    }
}