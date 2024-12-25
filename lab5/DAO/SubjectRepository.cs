using lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace lab5.DAO
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly JournalDbContext db;

        public SubjectRepository(JournalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            return db.Subjects.AsQueryable();
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            return await db.Subjects.FindAsync(id);
        }

        public async Task<Subject> AddSubject(Subject subject)
        {
            db.Subjects.Add(subject);
            await db.SaveChangesAsync();
            return subject;
        }

        public async Task<Subject> UpdateSubject(Subject model)
        {
            var existingSubject = await db.Subjects.Where(s => s.SubjectId == model.SubjectId).FirstOrDefaultAsync();
            {
                if (!string.IsNullOrEmpty(model.Name))existingSubject.Name = model.Name;

                db.Subjects.Update(existingSubject);
                await db.SaveChangesAsync();
            }
            return existingSubject!;
        }

        public async Task<bool> DeleteSubject(int id)
        {
            var subject = await db.Subjects.Where(p => p.SubjectId == id).FirstOrDefaultAsync();
            if (subject != null)
            {
                db.Subjects.Remove(subject);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
