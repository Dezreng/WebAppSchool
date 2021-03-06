﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppSchool.Models.CodeFirst
{
    public class ClassJournal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Требуется поле: Оценка")]
        public int Mark { get; set; }

        [Required(ErrorMessage ="Требуется поле: Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage ="Требуется поле: Присутствие")]
        public bool Presence { get; set; }

        public int SubjectId { get; set; }

        public int StudentId { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }
    }
}
