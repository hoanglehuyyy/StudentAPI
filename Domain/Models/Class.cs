using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Class
	{
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("class_name")]
        [MaxLength(10)]
        [Required]
        public string ClassName { get; set; }
        [Column("grade")]
        [Required]
        public int Grade { get; set; }

		public ICollection<Student> Students { get; set; }
	}
}

