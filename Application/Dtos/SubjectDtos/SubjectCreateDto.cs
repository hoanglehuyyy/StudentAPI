using System;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.SubjectDtos
{
	public class SubjectCreateDto
	{
        [MaxLength(10)]
        [Required]
        public string SubjectCode { get; set; }
        [MaxLength(30)]
        [Required]
        public string SubjectName { get; set; }
    }
}

