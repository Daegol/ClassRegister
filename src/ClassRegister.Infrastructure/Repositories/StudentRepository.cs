using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;

namespace ClassRegister.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _context;

        public StudentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Get() =>
            await Task.FromResult(_context.Students.ToList());

        public async Task<Student> GetById(Guid id) =>
            await Task.FromResult(_context.Students.SingleOrDefault(x => x.Id == id));

        public async Task<Student> GetByEmail(string email) =>
            await Task.FromResult(_context.Students.SingleOrDefault(x => x.Email == email));

        public async Task<Student> GetByPesel(string pesel) =>
            await Task.FromResult(_context.Students.SingleOrDefault(x => x.Pesel == pesel));

        public async Task AddStudent(Student student)
        {
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task AddClasses(IEnumerable<Guid> studentsId, Guid classId)
        {
            foreach (var studentId in studentsId)
            {
                var student = await GetById(studentId);
                student.ClassId = classId;
                _context.Students.Update(student);
            }

            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteStudent(string pesel)
        {
            var student = await GetByPesel(pesel);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}