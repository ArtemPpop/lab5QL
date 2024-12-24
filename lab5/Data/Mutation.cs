using lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace lab5.Data
{
    public class Mutation
    {
        public async Task<List<Student>> GetAllStudentsAsync([Service] JournalDbContext context)
        {
            return await context.Students
                .Select(s => new Student
                {
                    StudentId = s.StudentId,
                    Name = s.Name,
                    NumberClass = s.NumberClass,
                    DateOfBirth = s.DateOfBirth,
                    Grades = s.Grades,  
                    Attendances = s.Attendances 
                })
                .ToListAsync();
        }
        public async Task<List<Teacher>> GetAllTeachersAsync([Service] JournalDbContext context)
        {
            return await context.Teachers
                .Select(t => new Teacher
                {
                    TeacherId = t.TeacherId,
                    Name = t.Name,
                    Subjects = t.Subjects,
                    Grades = t.Grades 
                })
                .ToListAsync();
        }
        public async Task<List<Grade>> GetGradesByClassAndSubjectAsync([Service] JournalDbContext context, int numberClass, long subjectId)
        {
            return await context.Grades
                .Where(g => g.SubjectId == subjectId && g.Student.NumberClass == numberClass)
                .ToListAsync();
        }
        public async Task<int> CountAbsencesByClassAsync([Service] JournalDbContext context, int numberClass, DateTime startDate, DateTime endDate)
        {
            return await context.Attendances
                .CountAsync(a => a.Date >= startDate && a.Date <= endDate && !a.IsPresent && a.Student.NumberClass == numberClass);
        }
        public async Task<double> CalculateAverageGradeByClassAsync([Service] JournalDbContext context, int numberClass)
        {
            var grades = await context.Grades
                .Where(g => g.Student.NumberClass == numberClass)
                .ToListAsync();

            return grades.Any() ? grades.Average(g => g.Value) : 0;
        }
        public async Task<List<Teacher>> GetTeachersByClassAsync([Service] JournalDbContext context, int numberClass)
        {
            var subjectIds = await context.Grades
                .Where(g => g.Student.NumberClass == numberClass)
                .Select(g => g.SubjectId)
                .Distinct()
                .ToListAsync();

            return await context.Teachers
                .Where(t => t.Subjects.Any(s => subjectIds.Contains(s.SubjectId)))
                .Distinct()
                .ToListAsync();
        }
        public async Task<List<Teacher>> GetTeachersBySubjectAsync([Service] JournalDbContext context, long subjectId)
        {
            return await context.Grades
                .Where(g => g.SubjectId == subjectId)
                .Select(g => g.Teacher)
                .Distinct()
                .ToListAsync();
        }

        public async Task<double> CalculateAverageGradeBySubjectAsync([Service] JournalDbContext context, long subjectId)
        {
            var grades = await context.Grades
                .Where(g => g.SubjectId == subjectId)
                .ToListAsync();

            return grades.Any() ? grades.Average(g => g.Value) : 0;
        }


        public async Task<Dictionary<long, double>> GetStudentCardAsync(long studentId, [Service] JournalDbContext context)
        {
            var grades = await context.Grades
                .Where(g => g.StudentId == studentId)
                .GroupBy(g => g.SubjectId)
                .Select(grp => new
                {
                    SubjectId = grp.Key,
                    AverageGrade = grp.Average(g => g.Value)
                })
                .ToListAsync();

            return grades.ToDictionary(g => g.SubjectId, g => g.AverageGrade);
        }


        public async Task<List<Subject>> GetSubjectsByClassAsync([Service] JournalDbContext context, int numberClass)
        {
            var subjectIds = await context.Grades
                .Where(g => g.Student.NumberClass == numberClass)
                .Select(g => g.SubjectId)
                .Distinct()
                .ToListAsync();

            return await context.Subjects
                .Where(s => subjectIds.Contains(s.SubjectId))
                .ToListAsync();
        }

    }
}
