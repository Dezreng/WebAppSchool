using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Требуется поле: ФИО учителя")]
        [MaxLength(100)]
        public string FioTeacher { get; set; }

        [Required(ErrorMessage ="Требуется поле: Пол")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Требуется поле: Адрес")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage ="Требуется поле: Телефон")]
        [MaxLength(12)]
        [Range(375250000000, 375449999999, ErrorMessage ="Номер телефона неккоректен")]
        public string Telephone { get; set; }

        [Required(ErrorMessage ="Требуется поле: Паспорт")]
        [MaxLength(100)]
        public string Passport { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
