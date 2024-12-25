using lab5.DAO;
using lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace lab5.Data
{
    public class Mutation
    {

        public async Task<Student?> UpdateStudent([Service] IStudentRepository studentRepository, Student model)
        {
            return await studentRepository.UpdateStudent(model);
        }

        public async Task<bool> DeleteStudent([Service] IStudentRepository studentRepository, int id)
        {
            return await studentRepository.DeleteStudent(id);
        }

        public async Task<Student?> CreateStudent(
            [Service] IStudentRepository studentRepository,
            string name,
            int numberClass,
            DateTime dateOfBirth)
        {
            Student newStudent = new Student
            {
                Name = name,
                NumberClass = numberClass,
                DateOfBirth = dateOfBirth,

            };
            return await studentRepository.AddStudent(newStudent);
        }


        public async Task<Subject?> UpdateSubject([Service] ISubjectRepository subjectRepository, Subject model)
        {
            return await subjectRepository.UpdateSubject(model);
        }

        public async Task<bool> DeleteSubject([Service] ISubjectRepository subjectRepository, int id)
        {
            return await subjectRepository.DeleteSubject(id);
        }

        public async Task<Subject?> CreateSubject(
            [Service] ISubjectRepository subjectRepository,
            string name)
        {
            Subject newSubject = new Subject
            {
                Name = name
            };
            return await subjectRepository.AddSubject(newSubject);
        }

        public async Task<Teacher?> UpdateTeacher([Service] ITeacherRepository teacherRepository, Teacher model)
        {
            return await teacherRepository.UpdateTeacher(model);
        }

        public async Task<bool> DeleteTeacher([Service] ITeacherRepository teacherRepository, int id)
        {
            return await teacherRepository.DeleteTeacher(id);
        }

        public async Task<Teacher?> CreateTeacher(
            [Service] ITeacherRepository teacherRepository,
            string name)
        {
            Teacher newTeacher = new Teacher
            {
                Name = name,
         
            };
            return await teacherRepository.AddTeacher(newTeacher);
        }

        public async Task<Grade?> UpdateGrade([Service] IGradeRepository gradeRepository, Grade model)
        {
            return await gradeRepository.UpdateGrade(model);
        }

        public async Task<bool> DeleteGrade([Service] IGradeRepository gradeRepository, int id)
        {
            return await gradeRepository.DeleteGrade(id);
        }

        public async Task<Grade?> CreateGrade(
            [Service] IGradeRepository gradeRepository,
            int score,
            Student student,
            Teacher teacher,
            Subject subject)
        {
            Grade newGrade = new Grade
            {
                Subject = subject,
                Teacher = teacher,
                Student = student,
                Value = score
                
            };
            return await gradeRepository.AddGrade(newGrade);
        }

        public async Task<Attendance?> UpdateAttendance([Service] IAttendanceRepository attendanceRepository, Attendance model)
        {
            return await attendanceRepository.UpdateAttendance(model);
        }

        public async Task<bool> DeleteAttendance([Service] IAttendanceRepository attendanceRepository, int id)
        {
            return await attendanceRepository.DeleteAttendance(id);
        }

        public async Task<Attendance?> CreateAttendance(
            [Service] IAttendanceRepository attendanceRepository,
            DateTime date,
            bool isPresent,
            Student student)
        {
            Attendance newAttendance = new Attendance
            {
                Date = date,
                IsPresent = isPresent,
                Student = student
            };
            return await attendanceRepository.AddAttendance(newAttendance);
        }
        
    }

}