using System;
using Application.Dtos.SubjectDtos;

namespace Application.Services.Interfaces
{
	public interface ISubjectService
	{
		Task<bool> CheckSubjectExist(int subjectId);
		Task<SubjectDto> CreateNewSubject(SubjectCreateDto subjectCreateDto);
		Task<List<SimpleSubjectDto>> GetAllSubject();
		Task<SubjectDto> GetSubjectByCode(string subjectCode);
		Task UpdateSubject(SubjectUpdateDto subjectUpdateDto);
		Task DeleteSubject(int id);
	}
}

