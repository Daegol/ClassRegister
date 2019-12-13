using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface ISubjectService
    {
        Task AddSubject(SubjectToAddDto subject);
        Task<IEnumerable<SubjectDto>> GetSubjects();
        Task RemoveSubject(Guid subjectId);
        Task UpdateSubject(UpdateSubjectDto subject);
    }
}