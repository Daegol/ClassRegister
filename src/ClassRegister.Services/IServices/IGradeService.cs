using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;

namespace ClassRegister.Services.IServices
{
    public interface IGradeService
    {

        Task AddGrade(GradeToAdd grade);
        Task DeleteGrade(Guid id);
        Task UpdateGrade(GradeToUpdate updateGrade);
    }
}