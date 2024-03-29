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
    public class ParentRepository : IParentRepository
    {
        private readonly DatabaseContext _context;

        public ParentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parent>> Get()
        {
            return await Task.FromResult(_context.Parents.Include(x => x.Student).ToList());
        }

        public async Task<Parent> GetById(Guid id)
        {
            return await Task.FromResult(_context.Parents.Include(x => x.Student).ThenInclude(x => x.Class)
                .SingleOrDefault(x => x.Id == id));
        }

        public async Task<Parent> GetByIdWithGrades(Guid id)
        {
            return await Task.FromResult(_context.Parents.Include(x => x.Student).ThenInclude(x => x.Grades)
                .SingleOrDefault(x => x.Id == id));
        }

        public async Task<Parent> GetByEmail(string email)
        {
            return await Task.FromResult(_context.Parents.SingleOrDefault(x => x.Email == email));
        }

        public async Task<Parent> GetByPesel(string pesel)
        {
            return await Task.FromResult(_context.Parents.SingleOrDefault(x => x.Pesel == pesel));
        }

        public async Task AddParent(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task DeleteParent(string pesel)
        {
            var parent = await GetByPesel(pesel);
            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task UpdateParent(Parent parent)
        {
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task AssignStudent(Guid studentId, Guid parentId)
        {
            var parent = _context.Parents.SingleOrDefault(x => x.Id == parentId);
            parent.StudentId = studentId;
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}