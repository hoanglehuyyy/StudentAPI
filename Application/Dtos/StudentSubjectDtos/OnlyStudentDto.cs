using System;
using Application.Dtos.StudentDtos;

namespace Application.Dtos.StudentSubjectDtos
{
	public class OnlyStudentDto
	{
		public SimpleStudentDto Student { get; set; }
		public float? Mark { get; set; }
	}
}

