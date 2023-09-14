using System;
using Application.Dtos.ClassDtos;
using Application.Dtos.StudentDtos;
using Application.Dtos.StudentSubjectDtos;
using Application.Dtos.SubjectDtos;
using Application.Dtos.UserDtos;
using AutoMapper;
using Domain.Models;

namespace Application.Dtos
{
	public class MappingConfig : Profile
	{
		public MappingConfig()
		{
			CreateMap<User, UserDto>().ReverseMap();

			CreateMap<Class, ClassDto>().ReverseMap();
			CreateMap<Class, SimpleClassDto>();
			CreateMap<Class, ClassViewDto>().ForMember(c => c.NumOfStudents, opt =>
			{
				opt.MapFrom(src => src.Students.Count());
			});
			CreateMap<Class, ClassCreateDto>().ReverseMap();
			CreateMap<Class, ClassUpdateDto>().ReverseMap();

			CreateMap<Student, StudentDto>().ReverseMap();
			CreateMap<Student, SimpleStudentDto>();
			CreateMap<Student, StudentViewDto>().ForMember(s => s.ClassName, opt =>
			{
				opt.MapFrom(src => src.Class.ClassName);
			});
			CreateMap<Student, StudentCreateDto>().ReverseMap();
			CreateMap<Student, StudentUpdateDto>().ReverseMap();

			CreateMap<Subject, SubjectDto>().ReverseMap();
			CreateMap<Subject, SimpleSubjectDto>();
			CreateMap<Subject, SubjectCreateDto>().ReverseMap();
			CreateMap<Subject, SubjectUpdateDto>().ReverseMap();

			CreateMap<StudentSubject, OnlyStudentDto>();
			CreateMap<StudentSubject, OnlySubjectDto>();
		}
	}
}

