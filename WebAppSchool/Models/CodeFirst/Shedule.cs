using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Shedule
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Требуется поле: Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Требуется поле: День недели")]
        [MaxLength(15)]
        public string DayOfWeek { get; set; }

        [Required(ErrorMessage ="Требуется поле: Время начала")]
        public TimeSpan TimeStart { get; set; }

        [Required(ErrorMessage ="Требуется поле: Время окончания")]
        public TimeSpan TimeEnd { get; set; }

        public int TeacherId { get; set; }

        public int GroupClassId { get; set; }

        public int SubjectId { get; set; }

        public Teacher Teacher { get; set; }

        public GroupClass GroupClass { get; set; }

        public Subject Subject { get; set; }
    }
}
