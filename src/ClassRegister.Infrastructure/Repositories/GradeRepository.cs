using System;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;

namespace ClassRegister.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly DatabaseContext _context;

        public GradeRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Grade> GetById(Guid id) => 
            await Task.FromResult(_context.Grades.SingleOrDefault(x => x.Id == id));

        public async Task AddGrade(Grade grade)
        {
            await _context.AddAsync(grade);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteGrade(Guid id)
        {
            var grade = _context.Grades.SingleOrDefault(x => x.Id == id);
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateGrade(Grade grade)
        {
            _context.Grades.Update(grade);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}