using System;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface IGradeRepository
    {
        Task<Grade> GetById(Guid id);
        Task AddGrade(Grade grade);
        Task DeleteGrade(Guid id);
        Task UpdateGrade(Grade grade);
    }
}