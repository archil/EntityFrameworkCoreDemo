using LearningManagementSystem.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearningManagementSystem.Db.Migrations
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var students = new List<Student>();

            for (int i = 1; i < 51; i++)
            {
                students.Add(new Student
                {
                    StudentId = i,
                    Name = $"Student {i}"
                });
            }

            var subjects = new List<Subject>();

            for (int i = 1; i < 6; i++)
            {
                subjects.Add(new Subject
                {
                    SubjectId = i,
                    Name = $"Subject {i}"
                });
            }

            var studentSubjects = new List<StudentSubject>();
            Random random = new Random();

            foreach (var student in students)
            {
                int firstSubjectIndex = random.Next(0, subjects.Count);
                int secondSubjectIndex;

                do
                {
                    secondSubjectIndex = random.Next(0, subjects.Count);
                } while (firstSubjectIndex == secondSubjectIndex);


                studentSubjects.AddRange(new List<StudentSubject> {
                    new StudentSubject { StudentId = student.StudentId, SubjectId = subjects[firstSubjectIndex].SubjectId },
                    new StudentSubject { StudentId = student.StudentId, SubjectId = subjects[secondSubjectIndex].SubjectId }
                });
            }

            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<Subject>().HasData(subjects);
            modelBuilder.Entity<StudentSubject>().HasData(studentSubjects);
        }
    }
}
