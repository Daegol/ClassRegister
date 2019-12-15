using System;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;

namespace ClassRegister.Infrastructure.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly DatabaseContext _context;

        public LessonRepository(DatabaseContext context)
        {
            this._context = context;
        }
        public async Task AddLesson(Lesson lesson)
        {
            await _context.AddAsync(lesson);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task RemovePlan(Guid classId)
        {
            var lessons = _context.Lessons.Where(x => x.ClassId == classId).ToList();
            foreach (var lesson in lessons)
            {
                _context.Lessons.Remove(lesson);
            }

            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}