using lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace lab5.DAO
{
    public class GradeRepository : IGradeRepository
    {
        private readonly JournalDbContext db;

        public GradeRepository(JournalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Grade> GetAllGrades()
        {
            return db.Grades.AsQueryable();
        }

        public async Task<Grade> GetGradeById(int id)
        {
            return await db.Grades.FindAsync(id);
        }

        public async Task<Grade> AddGrade(Grade grade)
        {
            db.Grades.Add(grade);
            await db.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> UpdateGrade(Grade grade)
        {
            var existingGrade = await db.Grades.Where(g => g.GradeId == grade.GradeId).FirstOrDefaultAsync();
            if (existingGrade != null)
            {
                if (grade.SubjectId != 0) 
                    existingGrade.SubjectId = grade.SubjectId;
                if (grade.TeacherId != 0)
                    existingGrade.TeacherId = grade.TeacherId;
                if (grade.StudentId != 0)
                    existingGrade.StudentId = grade.StudentId;
                if (grade.Value >= 0)
                    existingGrade.Value = grade.Value;
                existingGrade.CreateAt = DateTime.Now;

                db.Grades.Update(existingGrade);
                await db.SaveChangesAsync();
            }
            return existingGrade!;
        }
        public async Task<bool> DeleteGrade(int id)
        {
            var grade = await db.Grades.Where(p => p.GradeId == id).FirstOrDefaultAsync();
            if (grade != null)
            {
                db.Grades.Remove(grade);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}