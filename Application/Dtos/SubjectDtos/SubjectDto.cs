using System;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Dtos.StudentSubjectDtos;

namespace Application.Dtos.SubjectDtos
{
	public class SubjectDto
	{
        public int Id { get; set; }
        [MaxLength(10)]
        public string SubjectCode { get; set; }
        [MaxLength(30)]
        public string SubjectName { get; set; }

        public ICollection<OnlyStudentDto> StudentSubjects { get; set; }
    }
}

