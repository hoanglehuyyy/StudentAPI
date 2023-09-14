using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
	public class User
	{
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[Column("user_name")]
		[MaxLength(30)]
		[Required]
		public string UserName { get; set; }
        [Column("password")]
        [MinLength(6)]
        [Required]
        public string Password { get; set; }
        [Column("name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [Column("role")]
        [Required]
        public string Role { get; set; }
	}
}

