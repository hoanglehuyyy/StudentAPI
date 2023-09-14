using System;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
	public interface IUser
	{
        Task<User> GetAsync(Expression<Func<User, bool>> filter = null, bool tracked = true);
        Task CreateAsync(User entity);
        Task UpdateAsync(User entity);
        Task RemoveAsync(User entity);
        Task SaveAsync();
    }
}

