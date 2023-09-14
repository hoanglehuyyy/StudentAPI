using System;
using Application.Dtos.StudentDtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.ClassDtos
{
	public class ClassCreateDto
	{
        [Column("class_name")]
        [MaxLength(10)]
        [Required]
        public string ClassName { get; set; }
        [Column("grade")]
        [Required]
        public int Grade { get; set; }
    }
}

