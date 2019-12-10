using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;

namespace ClassRegister.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DatabaseContext _context;

        public TeacherRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Teacher>> Get() =>
            await Task.FromResult(_context.Teachers.ToList());

        public async Task<Teacher> GetById(Guid id) =>
            await Task.FromResult(_context.Teachers.SingleOrDefault(x => x.Id == id));

        public async Task<Teacher> GetByEmail(string email) =>
            await Task.FromResult(_context.Teachers.SingleOrDefault(x => x.Email == email));

        public async Task<Teacher> GetByPesel(string pesel) =>
            await Task.FromResult(_context.Teachers.SingleOrDefault(x => x.Pesel == pesel));

        public async Task AddTeacher(Teacher Teacher)
        {
            await _context.AddAsync(Teacher);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteTeacher(string pesel)
        {
            var teacher = await GetByPesel(pesel);
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}