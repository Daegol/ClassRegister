using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace ClassRegister.Infrastructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DatabaseContext _context;

        public SubjectRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddSubject(Subject subject)
        {
            await _context.AddAsync(subject);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            var subjects = _context.Subjects
                .Include(x => x.Lessons)
                .ThenInclude(x => x.Class).ToList();
            return subjects;
        }

        public async Task RemoveSubject(Guid subjectId)
        {
            var subject = _context.Subjects.Include(x => x.Lessons).SingleOrDefault(x => x.Id == subjectId);
            var lesson = _context.Lessons.SingleOrDefault(x => x.SubjectId == subject.Id);
            if (lesson != null) _context.Lessons.Remove(lesson);
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateSubject(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Subject> GetById(Guid id) =>
            await Task.FromResult(_context.Subjects.Include(x => x.Lessons).SingleOrDefault(x => x.Id == id));
    }
}