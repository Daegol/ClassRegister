using System;
using System.Threading.Tasks;
using ClassRegister.Core.Model;

namespace ClassRegister.Core.Repositories
{
    public interface ILessonRepository
    {
        Task AddLesson(Lesson lesson);
        Task RemovePlan(Guid classId);
    }
}