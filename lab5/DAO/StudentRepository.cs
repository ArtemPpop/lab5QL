using lab5.Models;
using Microsoft.EntityFrameworkCore;

namespace lab5.DAO
{
    public class StudentRepository : IStudentRepository
    {
        private readonly JournalDbContext db;

        public StudentRepository(JournalDbContext db)
        {
            this.db = db;
        }   

        public IQueryable<Student> GetAllStudents()
        {
            return db.Students.AsQueryable();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await db.Students.FindAsync(id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student model)
        {
            var existingStudent = await db.Students
                .Where(s => s.StudentId == model.StudentId)
                .FirstOrDefaultAsync();

            if (existingStudent != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    existingStudent.Name = model.Name;
                if (model.NumberClass != 0)
                    existingStudent.NumberClass = model.NumberClass;
                if (model.DateOfBirth != default) 
                    existingStudent.DateOfBirth = model.DateOfBirth;
                if (model.Grades != null)
                    existingStudent.Grades = model.Grades;
                if (model.Attendances != null)
                    existingStudent.Attendances = model.Attendances;

                db.Students.Update(existingStudent);
                await db.SaveChangesAsync();
            }

            return existingStudent!;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var student = await db.Students.Where(p => p.StudentId == id).FirstOrDefaultAsync();
            if (student != null)
            {
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
