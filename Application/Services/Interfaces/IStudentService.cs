using System;
using Application.Dtos.StudentDtos;

namespace Application.Services.Interfaces
{
	public interface IStudentService
	{
		Task<bool> CheckStudentExist(int studentId);
		Task<StudentDto> CreateNewStudent(StudentCreateDto studentCreateDto);
		Task<List<StudentViewDto>> GetAllStudents();
		Task<List<StudentViewDto>> GetStudentsByName(string name);
        Task<List<SimpleStudentDto>> GetStudentsInClass(int classId);
        Task<List<SimpleStudentDto>> GetStudentsInClassByName(int classId, string name);
        Task<StudentDto> GetStudentById(int id);
		Task UpdateStudent(StudentUpdateDto studentDto);
		Task DeleteStudent(int id);
    }
}

