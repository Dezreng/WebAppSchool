using Microsoft.EntityFrameworkCore;
using System;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Shedule> Shedules { get; set; }

        public DbSet<ClassJournal> ClassJournals { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<GroupClass> GroupClasses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            int count = 10000;
            modelBuilder.Entity<Position>().HasData(InitDb.CreatePositions(count));
            modelBuilder.Entity<Teacher>().HasData(InitDb.CreateTeachers(count));
            modelBuilder.Entity<GroupClass>().HasData(InitDb.CreateGroupClasses(count));
            modelBuilder.Entity<Student>().HasData(InitDb.CreateStudents(count));
            modelBuilder.Entity<Subject>().HasData(InitDb.CreateSubjects(count));
            modelBuilder.Entity<Shedule>().HasData(InitDb.CreateShedules(count));
            modelBuilder.Entity<ClassJournal>().HasData(InitDb.CreateClassJournals(count));
        }
    }

    class InitDb
    {
        public static Position[] CreatePositions(int count)
        {
            string[] titlePosition = { "Учитель математики", "Учитель русского языка", "Учитель георграфии", "Учитель математики", "Учитель музыки", "Учитель физкультуры", "Учитель информатики" };
            int salary = 100;
            string responsibilities = "Педагогическое образование";
            string requirements = "Четкое исполнение своих обязанность при обучении";

            Random random = new Random();
            Position[] positions = new Position[count];

            for (int i = 0; i < count; i++)
            {
                positions[i] = new Position
                {
                    Id = i + 1,
                    TitlePosition = titlePosition[random.Next(0, titlePosition.Length)],
                    Salary = salary * random.Next(2, 15),
                    Responsibilities = responsibilities,
                    Requirements = requirements
                };
            }

            return positions;
        }

        public static Teacher[] CreateTeachers(int count)
        {
            string[] fioTeacherFem = { "Королева Лидия Ивановна", "Петрова Мария Викторовна", "Сосновская Алиса Андреевна" };
            string[] fioTeacherMal = { "Марчук Ян Валерьевич", "Лемешенко Алексей Михайлович", "Воробьев Алексей Викторович" };
            string[] address = { "Минск, ул. Минская, д. 6, кв. 7",
                                    "Рогачев. ул. Сосновая, д.3, кв. 1",
                                    "Брест, ул. Советская, д. 14, кв. 67",
                                    "Витебск, ул. Московская, д. 15, кв. 91",
                                    "Малоречье, ул. Крестьянская, д. 16, кв. 16" };
            string[] telephone = { "37544555574", "37529678998", "37525427889", "37533892447", "37544964963" };
            string[] passport = { "Выдан Советским РОВД г.Минска, 29.11.2011",
                                    "Выдан Брестским РОВД г.Бреста, 14.01.2013",
                                    "Выдан Рогачевским РОВД. г.Рогачева, 15.05.2013",
                                    "Выдан Могилевским УВД, г.Гомеля, 18.05.2015",
                                    "Выдан Бобруским РОВД, г.Бобруйск, 01.01.2016" };
            Random random = new Random();
            Teacher[] teachers = new Teacher[count];

            for (int i = 0; i < count; i++)
            {
                teachers[i] = new Teacher
                {
                    Id = i + 1,
                    Address = address[random.Next(0, address.Length)],
                    Telephone = telephone[random.Next(0, telephone.Length)] + random.Next(0, 9).ToString(),
                    Passport = passport[random.Next(0, passport.Length)],
                    PositionId = random.Next(1, count)
                };

                if (random.Next(0, 1) == 0)
                {
                    teachers[i].FioTeacher = fioTeacherFem[random.Next(0, fioTeacherFem.Length)];
                    teachers[i].Gender = "Женский";
                }
                else
                {
                    teachers[i].FioTeacher = fioTeacherMal[random.Next(0, fioTeacherMal.Length)];
                    teachers[i].Gender = "Мужской";
                }
            }

            return teachers;
        }

        public static GroupClass[] CreateGroupClasses(int count)
        {
            string[] classRoomTeacher = { "Ратников Михаил Александрович",
                "Цибульский Александр Маркович",
                "Асенчик Олег Данилович",
                "Бачурина Виктория Денисовна",
                "Прокопенко Александра Андреевна",
                "Шевцова Елена Васильевна" };
            string[] letter = { "А", "Б", "В", "Г", "Д" };
            int yearCreation = 1995;

            Random random = new Random();
            GroupClass[] groupClasses = new GroupClass[count];

            for (int i = 0; i < count; i++)
            {
                groupClasses[i] = new GroupClass
                {
                    Id = i + 1,
                    ClassRoomTeacher = classRoomTeacher[random.Next(0, classRoomTeacher.Length)],
                    NumberStudents = random.Next(5, 30),
                    Letter = letter[random.Next(0, letter.Length)],
                    YearStudy = random.Next(1, 12),
                    YearCreation = yearCreation + random.Next(0, 20),
                };
            }

            return groupClasses;
        }

        public static Student[] CreateStudents(int count)
        {
            string[] fioStudentFem = { "Одинцова Виктроия Сергеевна", "Ефанова Ксения Андреевна", "Москалева Алиса Антоновна" };
            string[] fioStudentMal = { "Гущенко Макар Генадьвевич", "Клименко Клим Иосифович", "Машук Никита Викторович" };

            string[] fioFatherFem = { "Одинцов Сергей Юрьевич", "Ефанов Андрей Александрович", "Москалев Антон Евгеньевич" };
            string[] fioMotherFem = { "Одинцова Марина Сергеевна", "Ефанова Лариса Александровна", "Москалева Анастасия Игоревна" };

            string[] fioFatherMal = { "Гущенко Генадий Михайлович", "Клименко Иосиф Антонович", "Машук Виктор Анисович" };
            string[] fioMotherMal = { "Гущенко Алина Викторовна", "Клименко Лидия Михайловна", "Машук Виктория Александровна" };

            string[] address = { "Красноселье, ул. Октяборьская, д. 6, кв. 7",
                                    "Речица. ул. Мищанская, д.3, кв. 1",
                                    "Брест, ул. Красносельская, д. 14, кв. 67",
                                    "Витебск, ул. Великоградская, д. 15, кв. 91",
                                    "Малоречье, ул. Победы, д. 16, кв. 16" };

            string addInform = "есть";

            Random random = new Random();
            Student[] students = new Student[count];

            for (int i = 0; i < count; i++)
            {
                students[i] = new Student
                {
                    Id = i + 1,
                    Address = address[random.Next(0, address.Length)],
                    AddInformation = addInform,
                    GroupClassId = random.Next(1, count)
                };

                if (random.Next(0, 1) == 0)
                {
                    int check = random.Next(0, 3);

                    students[i].FioStudent = fioStudentFem[check];
                    students[i].FioFather = fioFatherFem[check];
                    students[i].FioMother = fioMotherFem[check];
                    students[i].Gender = "Женский";
                }
                else
                {
                    int check = random.Next(0, 3);

                    students[i].FioStudent = fioStudentMal[check];
                    students[i].FioFather = fioFatherMal[check];
                    students[i].FioMother = fioMotherMal[check];
                    students[i].Gender = "Мужской";
                }
            }

            return students;
        }

        public static Subject[] CreateSubjects(int count)
        {
            string[] titleSubject = { "Математика", "Русский языка", "Информатика", "География", "Иностранный язык", "Музыка" };
            string[] description = { "Общий курс", "Правописание", "It-технологии", "Глобус", "Английский язык", "Изучение классической музыки" };

            Random random = new Random();
            Subject[] subjects = new Subject[count];

            for (int i = 0; i < count; i++)
            {
                int check = random.Next(0, titleSubject.Length);
                subjects[i] = new Subject
                {
                    Id = i + 1,
                    TitleSubject = titleSubject[check],
                    Description = description[check]
                };
            }

            return subjects;
        }

        public static Shedule[] CreateShedules(int count)
        {
            Random random = new Random();
            Shedule[] shedules = new Shedule[count];

            for (int i = 0; i < count; i++)
            {
                TimeSpan timeStart = new TimeSpan(random.Next(8, 20), random.Next(0, 60), 0);
                TimeSpan timeEnd = timeStart.Add(new TimeSpan(0, 45, 0));

                shedules[i] = new Shedule
                {
                    Id = i + 1,
                    Date = GenerateDateTime(),
                    DayOfWeek = random.Next(1, 7),
                    TimeStart = timeStart,
                    TimeEnd = timeEnd,
                    TeacherId = random.Next(1, count),
                    SubjectId = random.Next(1, count),
                    GroupClassId = random.Next(1, count)
                };
            }

            return shedules;
        }

        public static ClassJournal[] CreateClassJournals(int count)
        {
            Random random = new Random();
            ClassJournal[] classJournals = new ClassJournal[count];

            for (int i = 0; i < count; i++)
            {
                classJournals[i] = new ClassJournal
                {
                    Id = i + 1,
                    Mark = random.Next(1, 10),
                    Date = GenerateDateTime(),
                    Presence = random.Next(0, 1) == 0 ? false : true,
                    SubjectId = random.Next(1, count),
                    StudentId = random.Next(1, count)
                };
            }

            return classJournals;
        }

        private static DateTime GenerateDateTime()
        {
            Random random = new Random();

            int year = 2020;
            int month = random.Next(1, 13);
            int day = random.Next(1, 32);

            if (6 <= month && month <= 8)
            {
                month -= 3;
            }

            if (month == 2)
            {
                day = random.Next(1, 30);
            }
            if (month == 4 || month == 9 || month == 11)
            {
                day = random.Next(1, 31);
            }

            return new DateTime(year, month, day);
        }
    }

}
