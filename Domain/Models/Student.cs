using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class Student
	{
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("first_name")]
        [MaxLength(20)]
        [Required]
        public string FirstName { get; set; }
        [Column("middle_name")]
        [MaxLength(20)]
        public string MiddleName { get; set; }
        [Column("last_name")]
        [MaxLength(20)]
        [Required]
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => FirstName + (MiddleName != null ? " " + MiddleName : "") + " " + LastName;
        [Column("birthday", TypeName = "date")]
        [Required]
        public DateTime Birthday { get; set; }
        [Column("country")]
        [MaxLength(20)]
        [Required]
        public string Country { get; set; }
        [Column("address")]
        [MaxLength(50)]
        [Required]
        public string Address { get; set; }
        [Column("phone_number")]
        [MaxLength(15)]
        [Required]
        public string PhoneNumber { get; set; }
        [Column("class_id")]
        [ForeignKey("Class")]
        public int? ClassId { get; set; }

        public Class Class { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}

