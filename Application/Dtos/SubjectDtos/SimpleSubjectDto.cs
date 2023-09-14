using System;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.SubjectDtos
{
	public class SimpleSubjectDto
	{
        [MaxLength(10)]
        public string SubjectCode { get; set; }
        [MaxLength(30)]
        public string SubjectName { get; set; }
    }
}

