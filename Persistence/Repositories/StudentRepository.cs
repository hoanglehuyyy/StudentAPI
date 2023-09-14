using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Student entity)
        {
            await _db.Students.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> filter = null)
        {
            IQueryable<Student> query = _db.Students.Include(s => s.Class);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<Student> GetAsync(Expression<Func<Student, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Student> query = _db.Students.Include(s => s.Class).Include(s => s.StudentSubjects).ThenInclude(s => s.Subject);
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(Student entity)
        {
            _db.Students.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student entity)
        {
            _db.Students.Update(entity);
            await SaveAsync();
        }
    }
}

