using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class ClassJournal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Mark { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public bool Presence { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }
    }
}
