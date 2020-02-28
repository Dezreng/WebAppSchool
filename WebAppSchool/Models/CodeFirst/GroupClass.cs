using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSchool.Models.CodeFirst
{
    public class GroupClass
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ClassRoomTeacher { get; set; }

        [Required]
        public int NumberStudents { get; set; }

        [Required]
        [MaxLength(1)]
        public string Letter { get; set; }

        [Required]
        public int YearStudy { get; set; }

        [Required]
        public int YearCreation { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
