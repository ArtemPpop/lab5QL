using lab5.Models;

namespace lab5.DAO
{
        public interface IStudentRepository
        {
            IQueryable<Student> GetAllStudents();
            Task<Student> GetStudentById(int id);
            Task<Student> AddStudent(Student student);
            Task<Student> UpdateStudent(Student student);
            Task<bool> DeleteStudent(int id);
        }
}
