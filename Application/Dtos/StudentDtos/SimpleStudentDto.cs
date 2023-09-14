using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos.StudentDtos
{
	public class SimpleStudentDto
	{
        public string FullName { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

