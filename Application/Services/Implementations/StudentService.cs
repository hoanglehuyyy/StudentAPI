using System;
using Application.Dtos.StudentDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services.Implementations
{
	public class StudentService : IStudentService
	{
        private readonly IMapper _mapper;
        private readonly IStudent _studentRepo;
        public StudentService(IMapper mapper, IStudent studentRepo)
		{
            _mapper = mapper;
            _studentRepo = studentRepo;
		}

        public async Task<bool> CheckStudentExist(int studentId)
        {
            try
            {
                if (await _studentRepo.GetAsync(s => s.Id == studentId) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StudentDto> CreateNewStudent(StudentCreateDto studentCreateDto)
        {
            try
            {
                Student student = _mapper.Map<Student>(studentCreateDto);
                await _studentRepo.CreateAsync(student);
                return _mapper.Map<StudentDto>(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteStudent(int id)
        {
            try
            {
                Student student = await _studentRepo.GetAsync(s => s.Id == id);
                await _studentRepo.RemoveAsync(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StudentViewDto>> GetAllStudents()
        {
            try
            {
                List<Student> students = await _studentRepo.GetAllAsync();
                return _mapper.Map<List<StudentViewDto>>(students);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<StudentDto> GetStudentById(int id)
        {
            try
            {
                Student student = await _studentRepo.GetAsync(s => s.Id == id);
                return _mapper.Map<StudentDto>(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StudentViewDto>> GetStudentsByName(string name)
        {
            try
            {
                List<Student> students = await _studentRepo.GetAllAsync(s => s.FirstName.Contains(name));
                return _mapper.Map<List<StudentViewDto>>(students);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SimpleStudentDto>> GetStudentsInClass(int classId)
        {
            try
            {
                List<Student> students = await _studentRepo.GetAllAsync(s => s.ClassId == classId);
                return _mapper.Map<List<SimpleStudentDto>>(students);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SimpleStudentDto>> GetStudentsInClassByName(int classId, string name)
        {
            try
            {
                List<Student> students = await _studentRepo.GetAllAsync(s => s.ClassId == classId && s.FirstName.Contains(name));
                return _mapper.Map<List<SimpleStudentDto>>(students);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateStudent(StudentUpdateDto studentDto)
        {
            try
            {
                Student student = _mapper.Map<Student>(studentDto);
                await _studentRepo.UpdateAsync(student);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

