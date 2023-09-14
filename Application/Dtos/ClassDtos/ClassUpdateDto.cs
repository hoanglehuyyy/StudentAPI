using System;
using Application.Dtos.StudentDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.ClassDtos
{
	public class ClassUpdateDto
	{
        [Required]
        public int Id { get; set; }
        [MaxLength(10)]
        [Required]
        public string ClassName { get; set; }
        [Required]
        public int Grade { get; set; }
    }
}

