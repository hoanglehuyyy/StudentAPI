using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class Subject
	{
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("subject_code")]
        [MaxLength(10)]
        [Required]
        public string SubjectCode { get; set; }
        [Column("subject_name")]
        [MaxLength(30)]
        [Required]
        public string SubjectName { get; set; }

		public ICollection<StudentSubject> StudentSubjects { get; set; }
	}
}

