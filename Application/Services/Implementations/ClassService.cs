using System;
using Application.Dtos.ClassDtos;
using Application.Dtos.StudentDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services.Implementations
{
	public class ClassService : IClassService
	{
        private readonly IMapper _mapper;
        private readonly IClass _classRepo;
        private readonly IStudent _studentRepo;
		public ClassService(IMapper mapper, IClass classRepo, IStudent studentRepo)
		{
            _mapper = mapper;
            _classRepo = classRepo;
            _studentRepo = studentRepo;
		}

        public async Task<bool> CheckClassExist(int classId)
        {
            try
            {
                if (await _classRepo.GetAsync(c => c.Id == classId) != null)
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

        public async Task<bool> CheckClassNameConflict(string className, int? classId = null)
        {
            try
            {
                if (await _classRepo.GetAsync(c => c.Id != classId && c.ClassName == className) != null)
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

        public async Task<ClassDto> CreateNewClass(ClassCreateDto classDto)
        {

            try
            {
                Class @class = _mapper.Map<Class>(classDto);
                await _classRepo.CreateAsync(@class);
                Class newClass = await _classRepo.GetAsync(c => c == @class);
                return _mapper.Map<ClassDto>(newClass);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ClassViewDto>> GetAllClasses()
        {
            try
            {
                List<Class> classes = await _classRepo.GetAllAsync();
                return _mapper.Map<List<ClassViewDto>>(classes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ClassViewDto>> GetClassesByName(string name)
        {
            try
            {
                List<Class> classes = await _classRepo.GetAllAsync(c => c.ClassName.Contains(name));
                return _mapper.Map<List<ClassViewDto>>(classes);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ClassDto> GetClassById(int id)
        {
            try
            {
                Class @class = await _classRepo.GetAsync(c => c.Id == id);
                return _mapper.Map<ClassDto>(@class);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateClass(ClassUpdateDto classUpdateDto)
        {
            try
            {
                Class @class = _mapper.Map<Class>(classUpdateDto);
                await _classRepo.UpdateAsync(@class);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteClass(int id)
        {
            try
            {
                Class @class = await _classRepo.GetAsync(c => c.Id == id);
                foreach (var student in await _studentRepo.GetAllAsync(s => s.ClassId == id))
                {
                    student.ClassId = null;
                    await _studentRepo.UpdateAsync(student);
                }
                await _classRepo.RemoveAsync(@class);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

