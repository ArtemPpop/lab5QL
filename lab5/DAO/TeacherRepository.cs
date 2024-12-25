using lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace lab5.DAO
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly JournalDbContext db;

        public TeacherRepository(JournalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Teacher> GetAllTeachers()
        {
            return db.Teachers.AsQueryable();
        }

        public async Task<Teacher> GetTeacherById(int id)
        {
            return await db.Teachers.FindAsync(id);
        }

        public async Task<Teacher> AddTeacher(Teacher teacher)
        {
            db.Teachers.Add(teacher);
            await db.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateTeacher(Teacher model)
        {
            var existingTeacher = await db.Teachers.Where(s => s.TeacherId == model.TeacherId).FirstOrDefaultAsync();
            {
                if (!string.IsNullOrEmpty(model.Name)) existingTeacher.Name = model.Name;

                db.Teachers.Update(existingTeacher);
                await db.SaveChangesAsync();
            }
            return existingTeacher!;
        }

        public async Task<bool> DeleteTeacher(int id)
        {
            var teacher = await db.Teachers.Where(p => p.TeacherId == id).FirstOrDefaultAsync();
            if (teacher != null)
            {
                db.Teachers.Remove(teacher);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}