using Faker;
using lab5.Models;
using Microsoft.Extensions.Hosting;

namespace lab5.Data
{
    public class DataSeeder
    {
        public static void SeedData(JournalDbContext db)
        {
            if (!db.Teachers.Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    var teacher = new Teacher
                    {
                        Name = Name.FullName(),
                    };
                    db.Teachers.Add(teacher);
                }
                db.SaveChanges();
            }
            if (!db.Subjects.Any())
            {
                for (int i = 1; i <= 5; i++)
                {
                    var subject = new Subject
                    {
                        Name = "Предмет " + i
                    };
                    db.Subjects.Add(subject);
                }
                db.SaveChanges();
            }
            if (!db.Students.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var student = new Student
                    {
                        Name = Name.FullName(),
                        DateOfBirth = DateTime.Now.AddYears(-new Random().Next(6, 18)),
                    };
                    db.Students.Add(student);
                    var subjects = db.Subjects.ToList();
                    var teachers = db.Teachers.ToList();

                    for (int j = 0; j < 3; j++)
                    {
                        var subject = subjects[new Random().Next(subjects.Count)];
                        var teacher = teachers[new Random().Next(teachers.Count)];
                        var grade = new Grade
                        {
                            Value = new Random().Next(1, 6),
                            CreateAt = DateTime.Now,
                            Student = student,
                            Subject = subject,
                            Teacher = teacher
                        };
                        db.Grades.Add(grade);
                    }
                    for (int k = 0; k < 30; k++)
                    {
                        var attendance = new Attendance
                        {
                            Date = DateTime.Today.AddDays(-k),
                            IsPresent = new Random().Next(0, 2) == 1,
                            Student = student,
                        };
                        db.Attendances.Add(attendance);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}