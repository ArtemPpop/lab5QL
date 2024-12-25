using lab5.Models;

namespace lab5.DAO
{
    public interface IGradeRepository
    {
        Task<Grade?> AddGrade(Grade grade);
        Task<Grade?> UpdateGrade(Grade grade);
        Task<bool> DeleteGrade(int id);
        Task<Grade?> GetGradeById(int id);
        IQueryable<Grade> GetAllGrades();
    }
}
