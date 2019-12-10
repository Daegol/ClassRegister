using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;

namespace ClassRegister.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DatabaseContext _context;

        public ClassRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public async Task AddClass(Class group)
        {
            await _context.AddAsync(group);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}