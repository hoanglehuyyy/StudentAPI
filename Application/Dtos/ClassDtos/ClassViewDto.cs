using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.ClassDtos
{
	public class ClassViewDto
	{
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int Grade { get; set; }
        public int NumOfStudents { get; set; }
    }
}

