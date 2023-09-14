using System;
using Application.Dtos.SubjectDtos;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services.Implementations
{
	public class SubjectService : ISubjectService
	{
        private readonly IMapper _mapper;
        private readonly ISubject _subjectRepo;
		public SubjectService(IMapper mapper, ISubject subjectRepo)
		{
            _mapper = mapper;
            _subjectRepo = subjectRepo;
		}

        public async Task<bool> CheckSubjectExist(int subjectId)
        {
            try
            {
                if (await _subjectRepo.GetAsync(s => s.Id == subjectId) != null)
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

        public async Task<SubjectDto> CreateNewSubject(SubjectCreateDto subjectCreateDto)
        {
            try
            {
                Subject subject = _mapper.Map<Subject>(subjectCreateDto);
                await _subjectRepo.CreateAsync(subject);
                return _mapper.Map<SubjectDto>(subject);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteSubject(int id)
        {
            try
            {
                Subject subject = await _subjectRepo.GetAsync(s => s.Id == id);
                await _subjectRepo.RemoveAsync(subject);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<SimpleSubjectDto>> GetAllSubject()
        {
            try
            {
                List<Subject> subjects = await _subjectRepo.GetAllAsync();
                return _mapper.Map<List<SimpleSubjectDto>>(subjects);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SubjectDto> GetSubjectByCode(string subjectCode)
        {
            try
            {
                Subject subject = await _subjectRepo.GetAsync(s => s.SubjectCode == subjectCode);
                return _mapper.Map<SubjectDto>(subject);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateSubject(SubjectUpdateDto subjectUpdateDto)
        {
            try
            {
                Subject subject = _mapper.Map<Subject>(subjectUpdateDto);
                await _subjectRepo.UpdateAsync(subject);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

