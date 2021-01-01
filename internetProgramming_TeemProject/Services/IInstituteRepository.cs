using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internetProgramming_TeemProject.Entities;

namespace internetProgramming_TeemProject.Services
{
    public interface IInstituteRepository
    {
        Task<IEnumerable<Institute>> GetInstitutesAsync();
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<IEnumerable<StudentCourse>> GetCourseFromStudentAsync(Guid studentId);
        Task<IEnumerable<StudentCourse>> GetStudentFromCourseAsync(Guid courseId);
        Task<IEnumerable<TeacherCourse>> GetCourseFromTeacherAsync(Guid teacherId);
        Task<Institute> GetInstituteAsync(Guid instituteId);
        Task<Student> GetStudentsUseNumAsync(string studentNum);
        Task<Student> GetStudentNumAsync(string studentNum);
        Task<Teacher> GetTeacherNumAsync(string studentNum);
        Task<IEnumerable<Institute>> GetInstitutesAsync(IEnumerable<Guid> instituteIds);
        void AddInstitute(Institute institute);
        void UpdateInstitute(Institute institute);
        void DeleteInstitute(Institute institute);
        Task<bool> InstituteExistsAsync(Guid instituteId);
        Task<bool> StudentNumExistsAsync(string studentNum);

        Task<IEnumerable<Teacher>> GetTeachersAsync(Guid instituteId);
        Task<Teacher> GetTeacherAsync(Guid instituteId, Guid teacherId);
        Task<Account> GetTokenAsync(string username, string password, AccountType type);
        Task<Account> GetAccountAsync(string username, string password);
        void AddTeacher(Guid instituteId, Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
        Task<bool> SaveAsync();

        Task<IEnumerable<Student>> GetStudentsAsync(Guid instituteId);
        Task<Student> GetStudentAsync(Guid instituteId, Guid teacherId);
        void AddStudent(Guid instituteId, Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(Student student);

        Task<IEnumerable<Course>> GetCoursesAsync();
        Task<Course> GetCourseAsync(Guid courseId);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(Course course);

        void UpdatePassword(Account account);
    }
}
