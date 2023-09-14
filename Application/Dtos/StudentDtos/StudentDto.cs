using System;
using Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Application.Dtos.ClassDtos;
using Application.Dtos.StudentSubjectDtos;

namespace Application.Dtos.StudentDtos
{
	public class StudentDto
	{
        [Required]
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string MiddleName { get; set; }
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }
        public string FullName => FirstName + (MiddleName != null ? " " + MiddleName : "") + " " + LastName;
        [Required]
        public DateTime Birthday { get; set; }
        [MaxLength(20)]
        [Required]
        public string Country { get; set; }
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }
        [MaxLength(15)]
        [Required]
        public string PhoneNumber { get; set; }
        public int? ClassId { get; set; }

        public SimpleClassDto Class { get; set; }
        public ICollection<OnlySubjectDto> StudentSubjects { get; set; }
    }
}

