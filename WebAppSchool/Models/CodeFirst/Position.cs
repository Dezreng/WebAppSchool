using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string TitlePosition { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        [MaxLength(100)]
        public string Responsibilities { get; set; }

        [Required]
        [MaxLength(100)]
        public string Requirements { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
