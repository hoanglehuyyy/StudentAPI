using System;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Dtos.StudentDtos;

namespace Application.Dtos.ClassDtos
{
	public class ClassDto
	{
        [Required]
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int Grade { get; set; }

        public ICollection<SimpleStudentDto> Students { get; set; }
    }
}

