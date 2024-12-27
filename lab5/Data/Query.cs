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
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Teacher")]
        public IQueryable<Teacher> GetTeachers([Service] ITeacherRepository teacherRepository) => teacherRepository.GetAllTeachers();
        [UseProjection]
        public async Task<Teacher> GetTeacherById([Service] ITeacherRepository teacherRepository, int id)
        {
            return await teacherRepository.GetTeacherById(id);

        }

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Subject")]
        public IQueryable<Subject> GetSubjects([Service] ISubjectRepository subjectRepository) => subjectRepository.GetAllSubjects();
        [UseProjection]
        public async Task<Subject> GetSubjectById([Service] ISubjectRepository subjectRepository, int id)
        {
            return  await subjectRepository.GetSubjectById(id);
            
        }
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Grade")]
        public IQueryable<Grade> GetGrades([Service] IGradeRepository gradeRepository) => gradeRepository.GetAllGrades();
        [UseProjection]
        public async Task<Grade> GetGradeById([Service] IGradeRepository gradeRepository, int id)
        {
            return await gradeRepository.GetGradeById(id);
           
        }
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Attendance")]
        public IQueryable<Attendance> GetAttendances([Service] IAttendanceRepository attendanceRepository) => attendanceRepository.GetAllAttendances();
        [UseProjection]
        public async Task<Attendance> GetAttendanceById([Service] IAttendanceRepository attendanceRepository, int id)
        {
            return await attendanceRepository.GetAttendanceById(id);
            
        }
    }
}
