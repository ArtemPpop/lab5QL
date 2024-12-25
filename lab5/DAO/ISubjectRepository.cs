using lab5.Models;

namespace lab5.DAO
{
    public interface ISubjectRepository
    {
        Task<Subject?> AddSubject(Subject subject);
        Task<Subject?> UpdateSubject(Subject subject);
        Task<bool> DeleteSubject(int id);
        Task<Subject?> GetSubjectById(int id);
        IQueryable<Subject> GetAllSubjects();
    }
}
