using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSchool.Models.CodeFirst
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FioStudent { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(100)]
        public string FioFather { get; set; }

        [Required]
        [MaxLength(100)]
        public string FioMother { get; set; }

        [Required]
        [MaxLength(100)]
        public string AddInformation { get; set; }

        public int GroupClassId { get; set; }

        public GroupClass GroupClass { get; set; }

        public ICollection<ClassJournal> ClassJournals { get; set; }
    }
}
