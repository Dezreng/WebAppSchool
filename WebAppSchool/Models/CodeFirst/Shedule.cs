using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Shedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public int DayOfWeek { get; set; }

        [Required]
        public TimeSpan TimeStart { get; set; }

        [Required]
        public TimeSpan TimeEnd { get; set; }

        [Required]
        public int TeacherId { get; set; }

        [Required]
        public int GroupClassId { get; set; }

        [Required]
        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }

        public GroupClass GroupClass { get; set; }

        public Subject Subject { get; set; }
    }
}
