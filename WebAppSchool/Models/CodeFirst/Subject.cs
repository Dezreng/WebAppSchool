using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppSchool.Models.CodeFirst
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string TitleSubject { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<ClassJournal> ClassJournals { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
