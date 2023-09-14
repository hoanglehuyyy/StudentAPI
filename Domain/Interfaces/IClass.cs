using System;
using System.Linq.Expressions;
using Domain.Models;

namespace Domain.Interfaces
{
	public interface IClass
	{
		Task<List<Class>> GetAllAsync(Expression<Func<Class, bool>> filter = null);
		Task<Class> GetAsync(Expression<Func<Class, bool>> filter = null, bool tracked = true);
		Task CreateAsync(Class entity);
		Task UpdateAsync(Class entity);
		Task RemoveAsync(Class entity);
		Task SaveAsync();
	}
}

