using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class GroupClass
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Требуется поле: Классный руководитель")]
        [MinLength(10), MaxLength(100)]
        public string ClassRoomTeacher { get; set; }

        [Required(ErrorMessage = "Требуется поле: Количество учеников")]
        public int NumberStudents { get; set; }

        [Required(ErrorMessage = "Требуется поле: Буква класса")]
        [MinLength(1), MaxLength(1)]
        public string Letter { get; set; }

        [Required(ErrorMessage = "Требуется поле: Год обучения")]
        [Range(1, 12, ErrorMessage = "Год обучения должен быть между 1 и 12")]
        public int YearStudy { get; set; }

        [Required(ErrorMessage = "Требуется поле: Год создания")]
        [Range(1995, 2020, ErrorMessage = "Год создания должен быть между 1995 и 2020")]
        public int YearCreation { get; set; }

        public ICollection<Student> Students { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
