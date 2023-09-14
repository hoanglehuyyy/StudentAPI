using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class StudentSubject
	{
        [Column("student_id")]
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        [Column("subject_id")]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        [Range(0.0, 10.0)]
		public float? Mark { get; set; }

		public Student Student { get; set; }
		public Subject Subject { get; set; }
	}
}

