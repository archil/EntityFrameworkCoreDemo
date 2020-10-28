using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework!");


            Subject math = new Subject()
            {
                Name = "Math"
            };

            Subject programming = new Subject()
            {
                Name = "Programming"
            };

            Student archil = new Student
            {
                Name = "Archil"
            };

            Student giorgi = new Student
            {
                Name = "George"
            };

            List<StudentSubject> studentSubjects = new List<StudentSubject>()
            {
                new StudentSubject() { Student = archil, Subject = math },
                new StudentSubject() { Student = archil, Subject = programming },
            };

            archil.Subjects = studentSubjects;
            giorgi.Subjects = new List<StudentSubject>()
            {
                new StudentSubject() { Student = giorgi, Subject = math },
            };

            using (BloggingDbContext db = new BloggingDbContext())
            {
                db.Students.Add(archil);
                db.Students.Add(giorgi);

                db.SaveChanges();
            }

            using (var db = new BloggingDbContext())
            {

                for (int i = 0; i < 50; i++)
                {
                    db.Students.Add(new Student()
                    {
                        Name = "Student 1",
                        Subjects = new List<StudentSubject>
                        {
                            new StudentSubject{ Subject = new Subject{  Name = "c#" } }
                        }
                    });
                }

                for (int i = 0; i < 5; i++)
                {
                    db.Subjects.Add(new Subject()
                    {
                        Name = "Subject 1"
                    });
                }

                db.SaveChanges();

                var studentCount = db.Students.Count();


                Console.WriteLine($"There are {studentCount} students in database");
            }

            Console.ReadLine();
        }
    }

    public class BloggingDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=BloggingDb;Integrated security=true;");
        }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<StudentSubject> Subjects { get; set; }
    }

    public class StudentSubject
    {
        public int StudentSubjectId { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }

    public class Subject
    {
        public int SubjectId { get; set; }
        public string Name { get; set; }
        public List<StudentSubject> Students { get; set; }
    }
}
