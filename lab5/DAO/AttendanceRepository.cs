using lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace lab5.DAO
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly JournalDbContext db;

        public AttendanceRepository(JournalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Attendance> GetAllAttendances()
        {
            return db.Attendances.AsQueryable();
        }

        public async Task<Attendance> GetAttendanceById(int id)
        {
            return await db.Attendances.FindAsync(id);
        }

        public async Task<Attendance> AddAttendance(Attendance attendance)
        {
            db.Attendances.Add(attendance);
            await db.SaveChangesAsync();
            return attendance;
        }

        public async Task<Attendance> UpdateAttendance(Attendance model)
        {
            var existingAttendance = await db.Attendances
                .Where(a => a.AttendanceId == model.AttendanceId)
                .FirstOrDefaultAsync();

            if (existingAttendance != null)
            {
               
                existingAttendance.IsPresent = model.IsPresent;
                if (model.Student != null)
                    existingAttendance.Student = model.Student;
                existingAttendance.Date = DateTime.Now; 

                db.Attendances.Update(existingAttendance);
                await db.SaveChangesAsync();
            }

            return existingAttendance!;
        }

        public async Task<bool> DeleteAttendance(int id)
        {
            var attendance = await db.Attendances.Where(p => p.AttendanceId == id).FirstOrDefaultAsync();
            if (attendance != null)
            {
                db.Attendances.Remove(attendance);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
     
    }
}