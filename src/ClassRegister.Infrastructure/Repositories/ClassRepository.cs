using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ClassRegister.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DatabaseContext _context;

        public ClassRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public async Task<IEnumerable<Class>> GetAll() =>
            await Task.FromResult(_context.Classes.Include(x => x.Students).ToList()); 

        public async Task AddClass(Class group)
        {
            await _context.AddAsync(group);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<Class> GetById(Guid? id) =>
            await Task.FromResult(_context.Classes.SingleOrDefault(x => x.Id == id));

        public async Task DeleteClass(Guid id)
        {
            var cl = _context.Classes.Include(x => x.Students).SingleOrDefault(x => x.Id == id);
            _context.Classes.Remove(cl);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateClass(Class grup)
        {
            _context.Classes.Update(grup);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}