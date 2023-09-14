using System;
using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
	public interface IStudent
	{
        Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> filter = null);
        Task<Student> GetAsync(Expression<Func<Student, bool>> filter = null, bool tracked = true);
        Task CreateAsync(Student entity);
        Task UpdateAsync(Student entity);
        Task RemoveAsync(Student entity);
        Task SaveAsync();
    }
}

