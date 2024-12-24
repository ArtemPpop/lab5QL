using lab5.DAO;
using lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace lab5.Data
{
    public class Quary
    {
     
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Students")]
        public IQueryable<Student> GetStudents([Service] JournalDbContext context) => context.Students;
        [UseProjection]
        public async Task<Student> GetPostById([Service] IStudentRepository studentRepository, int id)
        {
            Student student = await studentRepository.GetStudentById(id);
            return student;
        }
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Teacher")]
        public IQueryable<Teacher> GetTeachers([Service] JournalDbContext context) => context.Teachers;
        [UseProjection]
        public async Task<Teacher> GetPostById([Service] ITeacherRepository teacherRepository, int id)
        {
            Teacher teacher = await teacherRepository.GetTeacherById(id);
            return teacher;
        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Subject")]
        public IQueryable<Subject> GetSubjects([Service] JournalDbContext context) => context.Subjects;
        [UseProjection]
        public async Task<Subject> GetPostById([Service] ISubjectRepository subjectRepository, int id)
        {
            Subject subject = await subjectRepository.GetSubjectById(id);
            return subject;
        }
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Grade")]
        public IQueryable<Grade> GetGrades([Service] JournalDbContext context) => context.Grades;
        [UseProjection]
        public async Task<Grade> GetPostById([Service] IGradeRepository gradeRepository, int id)
        {
            Grade grade = await gradeRepository.GetGradeById(id);
            return grade;
        }
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Attendance")]
        public IQueryable<Attendance> GetAttendances([Service] JournalDbContext context) => context.Attendances;
        [UseProjection]
        public async Task<Attendance> GetPostById([Service] IAttendanceRepository attendanceRepository, int id)
        {
            Attendance attendance = await attendanceRepository.GetAttendanceById(id);
            return attendance;
        }

    }
}
