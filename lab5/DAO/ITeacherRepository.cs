using lab5.Models;

namespace lab5.DAO
{
    public interface ITeacherRepository
    {
        Task<Teacher> AddTeacher(Teacher teacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<bool> DeleteTeacher(int id);
        Task<Teacher> GetTeacherById(int id);
        IQueryable<Teacher> GetAllTeachers();
    }
}
