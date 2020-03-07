using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Требуется поле: Название предмета")]
        [MaxLength(25)]
        public string TitleSubject { get; set; }

        [Required(ErrorMessage ="Требуется поле: Описание предмета")]
        [MaxLength(100)]
        public string Description { get; set; }

        public ICollection<ClassJournal> ClassJournals { get; set; }

        public ICollection<Shedule> Shedules { get; set; }
    }
}
