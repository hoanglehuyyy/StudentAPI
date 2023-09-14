using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
	public class SubjectRepository : ISubject
	{
        private readonly ApplicationDbContext _db;
		public SubjectRepository(ApplicationDbContext db)
		{
            _db = db;
		}

        public async Task CreateAsync(Subject entity)
        {
            await _db.Subjects.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Subject>> GetAllAsync(Expression<Func<Subject, bool>> filter = null)
        {
            IQueryable<Subject> query = _db.Subjects;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<Subject> GetAsync(Expression<Func<Subject, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Subject> query = _db.Subjects.Include(s => s.StudentSubjects).ThenInclude(s => s.Student);
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

        public async Task RemoveAsync(Subject entity)
        {
            _db.Subjects.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subject entity)
        {
            _db.Subjects.Update(entity);
            await SaveAsync();
        }
    }
}

