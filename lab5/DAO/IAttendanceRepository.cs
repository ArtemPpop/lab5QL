using lab5.Models;

namespace lab5.DAO
{
    public interface IAttendanceRepository
    {
        Task<Attendance> AddAttendance(Attendance attendance);
        Task<Attendance> UpdateAttendance(Attendance attendance);
        Task<bool> DeleteAttendance(int id);
        Task<Attendance> GetAttendanceById(int id);
        IQueryable<Attendance> GetAllAttendances();
    }
}
