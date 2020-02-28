using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSchool.Models.CodeFirst
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FioTeacher { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(12)]
        public string Telephone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Passport { get; set; }

        [Required]
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
