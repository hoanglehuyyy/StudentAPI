using System;
using Application.Dtos.SubjectDtos;

namespace Application.Dtos.StudentSubjectDtos
{
	public class OnlySubjectDto
	{
		public SimpleSubjectDto Subject { get; set; }
		public float? Mark { get; set; }
	}
}

