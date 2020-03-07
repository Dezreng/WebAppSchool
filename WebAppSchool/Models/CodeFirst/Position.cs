using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Требуется поле: Название должности")]
        [MaxLength(25)]
        public string TitlePosition { get; set; }

        [Required(ErrorMessage ="Требуется поле: Оклад")]
        public int Salary { get; set; }

        [Required(ErrorMessage ="Требуется поле: Требования")]
        [MaxLength(100)]
        public string Responsibilities { get; set; }

        [Required(ErrorMessage ="Требуется поле: Обязанности")]
        [MaxLength(100)]
        public string Requirements { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}
