using System;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
	public interface ISubject
	{
        Task<List<Subject>> GetAllAsync(Expression<Func<Subject, bool>> filter = null);
        Task<Subject> GetAsync(Expression<Func<Subject, bool>> filter = null, bool tracked = true);
        Task CreateAsync(Subject entity);
        Task UpdateAsync(Subject entity);
        Task RemoveAsync(Subject entity);
        Task SaveAsync();
    }
}

