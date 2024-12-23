using lab5.Models;
using Microsoft.Extensions.Hosting;

namespace lab5.Data
{
    public class Quary
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Attendance> GetAttendances([Service] JournalDbContext context) => context.Attendances;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Grade> GetGrades([Service] JournalDbContext context) => context.Grades;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> GetStudents([Service] JournalDbContext context) => context.Students;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Subject> GetSubjects([Service] JournalDbContext context) => context.Subjects;
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Teacher> GetTeachers([Service] JournalDbContext context) => context.Teachers;
    }
}
