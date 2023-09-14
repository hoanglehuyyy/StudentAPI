using System;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
	public class ClassRepository : IClass
	{
        private readonly ApplicationDbContext _db;
        public ClassRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Class entity)
        {
            await _db.Classes.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<List<Class>> GetAllAsync(Expression<Func<Class, bool>> filter = null)
        {
            IQueryable<Class> query = _db.Classes.Include(c => c.Students);
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<Class> GetAsync(Expression<Func<Class, bool>> filter = null, bool tracked = true)
        {
            IQueryable<Class> query = _db.Classes.Include(c => c.Students);
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

        public async Task UpdateAsync(Class entity)
        {
            _db.Classes.Update(entity);
            await SaveAsync();
        }

        public async Task RemoveAsync(Class entity)
        {
            _db.Classes.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}

