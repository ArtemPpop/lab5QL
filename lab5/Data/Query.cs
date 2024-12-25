using lab5.DAO;
using lab5.Models;

namespace lab5.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Students")]
        public IQueryable<Student> GetStudents([Service] IStudentRepository studentRepository) => studentRepository.GetAllStudents();
        [UseProjection]
        public async Task<Student> GetStudentById([Service] IStudentRepository studentRepository, int id)
        {
            return await studentRepository.GetStudentById(id);
        }
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //[GraphQLDescription("Method used to get list of all Teacher")]
        //public IQueryable<Teacher> GetTeachers([Service] ITeacherRepository teacherRepository) => teacherRepository.GetAllTeachers();
        //[UseProjection]
        //public async Task<Teacher> GetTeacherById([Service] ITeacherRepository teacherRepository, int id)
        //{
        //    return await teacherRepository.GetTeacherById(id);

        //}

        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //[GraphQLDescription("Method used to get list of all Subject")]
        //public IQueryable<Subject> GetSubjects([Service] JournalDbContext context) => context.Subjects;
        //[UseProjection]
        //public async Task<Subject> GetSubjectById([Service] ISubjectRepository subjectRepository, int id)
        //{
        //    Subject subject = await subjectRepository.GetSubjectById(id);
        //    return subject;
        //}
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //[GraphQLDescription("Method used to get list of all Grade")]
        //public IQueryable<Grade> GetGrades([Service] JournalDbContext context) => context.Grades;
        //[UseProjection]
        //public async Task<Grade> GetGradeById([Service] IGradeRepository gradeRepository, int id)
        //{
        //    Grade grade = await gradeRepository.GetGradeById(id);
        //    return grade;
        //}
        //[UseProjection]
        //[UseFiltering]
        //[UseSorting]
        //[GraphQLDescription("Method used to get list of all Attendance")]
        //public IQueryable<Attendance> GetAttendances([Service] JournalDbContext context) => context.Attendances;
        //[UseProjection]
        //public async Task<Attendance> GetAttendanceById([Service] IAttendanceRepository attendanceRepository, int id)
        //{
        //    Attendance attendance = await attendanceRepository.GetAttendanceById(id);
        //    return attendance;
        //}
    }
}
