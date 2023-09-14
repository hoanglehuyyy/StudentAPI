using System;
using Application.Dtos.ClassDtos;

namespace Application.Services.Interfaces
{
	public interface IClassService
	{
		Task<bool> CheckClassExist(int classId);
		Task<bool> CheckClassNameConflict(string className, int? classId = null);
		Task<ClassDto> CreateNewClass(ClassCreateDto @class);
		Task<List<ClassViewDto>> GetAllClasses();
		Task<List<ClassViewDto>> GetClassesByName(string name);
        Task<ClassDto> GetClassById(int id);
        Task UpdateClass(ClassUpdateDto @class);
        Task DeleteClass(int id);
	}
}

