using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Shedule> Shedules { get; set; }

        public DbSet<ClassJournal> ClassJournals { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<GroupClass> GroupClasses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
