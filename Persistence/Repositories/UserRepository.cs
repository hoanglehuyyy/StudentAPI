using System;
using System.Linq.Expressions;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Persistence.Repositories
{
	public class UserRepository : IUser
	{
		private readonly ApplicationDbContext _db;
		public UserRepository(ApplicationDbContext db)
		{
			_db = db;
		}

        public async Task CreateAsync(User entity)
        {
            await _db.Users.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true)
        {
            return(await _db.Users.FirstOrDefaultAsync(filter));            
        }

        public async Task RemoveAsync(User entity)
        {
            _db.Users.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _db.Users.Update(entity);
            await SaveAsync();
        }
    }
}

