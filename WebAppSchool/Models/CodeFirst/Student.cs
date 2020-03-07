using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Требуется поле: ФИО студента")]
        [MaxLength(100)]
        public string FioStudent { get; set; }

        [Required(ErrorMessage ="Требуется поле: Пол")]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage ="Требуется поле: Адрес")]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage ="Требуется поле: ФИО отца")]
        [MaxLength(100)]
        public string FioFather { get; set; }

        [Required(ErrorMessage ="Требуется поле: ФИО матери")]
        [MaxLength(100)]
        public string FioMother { get; set; }

        [Required(ErrorMessage ="Требуется поле: Доп. информация")]
        [MaxLength(100)]
        public string AddInformation { get; set; }

        public int GroupClassId { get; set; }

        public GroupClass GroupClass { get; set; }

        public ICollection<ClassJournal> ClassJournals { get; set; }
    }
}
