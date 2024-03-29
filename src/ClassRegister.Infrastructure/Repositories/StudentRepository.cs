﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace ClassRegister.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DatabaseContext _context;

        public StudentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> Get()
        {
            return await Task.FromResult(_context.Students.Include(x => x.Grades).Include(x => x.Parent).ToList());
        }

        public async Task<Student> GetById(Guid id)
        {
            return await Task.FromResult(_context.Students.SingleOrDefault(x => x.Id == id));
        }

        public async Task<Student> GetByEmail(string email)
        {
            return await Task.FromResult(_context.Students.SingleOrDefault(x => x.Email == email));
        }

        public async Task<Student> GetByPesel(string pesel)
        {
            return await Task.FromResult(_context.Students.Include(x => x.Parent).SingleOrDefault(x => x.Pesel == pesel));
        }

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