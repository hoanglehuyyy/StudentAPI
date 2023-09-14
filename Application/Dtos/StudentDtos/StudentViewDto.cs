using System;
using Application.Dtos.ClassDtos;
using Application.Dtos.StudentSubjectDtos;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.StudentDtos
{
	public class StudentViewDto
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ClassName { get; set; }
    }
}

