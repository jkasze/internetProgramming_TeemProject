using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internetProgramming_TeemProject.Entities;
using internetProgramming_TeemProject.Data;
using Microsoft.EntityFrameworkCore;

namespace internetProgramming_TeemProject.Services
{
    public class InstituteRepository : IInstituteRepository
    {
        private readonly ProjectDbContext _context;

        public InstituteRepository(ProjectDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddInstitute(Institute institute)
        {
            if (institute == null)
            {
                throw new ArgumentNullException(nameof(institute));
            }
            institute.Id = Guid.NewGuid();
            if(institute.Teachers != null)
            {
                foreach (var teacher in institute.Teachers)
                {
                    teacher.Id = Guid.NewGuid();
                }
            }
            

            _context.Institutes.Add(institute);
        }
        public void AddCourse(Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            course.Id = Guid.NewGuid();

            _context.Courses.Add(course);
        }

        public void AddTeacher(Guid instituteId, Teacher teacher)
        {
            if (instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }

            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }

            teacher.InstituteId = instituteId;
            _context.Teachers.Add(teacher);
        }

        public async Task<bool> InstituteExistsAsync(Guid instituteId)
        {
            if (instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }

            return await _context.Institutes.AnyAsync(x => x.Id == instituteId);
        }
        public async Task<bool> StudentNumExistsAsync(string studentNum)
        {
            if (studentNum == null)
            {
                throw new ArgumentNullException(nameof(studentNum));
            }

            return await _context.Students.AnyAsync(x => x.StudentNum == studentNum);
        }
        public async Task<bool>CourseExistAsync(Guid courseId)
        {
            if(courseId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }
            return await _context.Courses.AnyAsync(x => x.Id == courseId);
        }


        public void DeleteInstitute(Institute institute)
        {
            if (institute == null)
            {
                throw new ArgumentNullException(nameof(institute));
            }

            _context.Institutes.Remove(institute);
        }
        public void DeleteCourse(Course course)
        {
            if(course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Remove(course);
        }

        public void DeleteTeacher(Teacher teacher)
        {
            if (teacher == null)
            { 
                throw new NotImplementedException(); 
            }

            _context.Teachers.Remove(teacher);
        }

        public async Task<Institute> GetInstituteAsync(Guid instituteId)
        {
            if (instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }

            return await _context.Institutes.FirstOrDefaultAsync(x => x.Id == instituteId);
        }

        public async Task<Student> GetStudentNumAsync(string studentNum)
        {
            if (studentNum == "")
            {
                throw new ArgumentNullException(nameof(studentNum));
            }

            return await _context.Students.FirstOrDefaultAsync(x => x.StudentNum == studentNum);
        }
        
        public async Task<Teacher> GetTeacherNumAsync(string teacherNum)
        {
            if (teacherNum == "")
            {
                throw new ArgumentNullException(nameof(teacherNum));
            }

            return await _context.Teachers.FirstOrDefaultAsync(x => x.TeacherNum == teacherNum);
        }

        public  Task<Account> GetTokenAsync(string username, string password) 
        {
            if(username == null)
            {
                throw new ArgumentNullException(nameof(username));
            }
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }
            return _context.Accounts
                    .Where(x => x.Password == password & x.UserName == username)
                        .FirstOrDefaultAsync();
        }

        public async Task<Course> GetCourseAsync(Guid courseId)
        {
            if(courseId==Guid.Empty)
            {
                throw new ArgumentNullException(nameof(courseId));
            }


            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == courseId);
        }
        public async Task<Student> GetStudentsUseNumAsync(string studentNum)
        {
            if(studentNum==null)
            {
                throw new ArgumentNullException(nameof(studentNum));
            }

            return await _context.Students.FirstOrDefaultAsync(x => x.StudentNum == studentNum);
        }
        public async Task<IEnumerable<Institute>> GetInstitutesAsync()
        {
            return await _context.Institutes.ToListAsync();
        }
        public async Task<IEnumerable<Course>>GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<StudentCourse>> GetCourseFromStudentAsync(Guid studentId)
        {
            if (studentId == Guid.Empty)
            {
                throw new ArgumentException(nameof(studentId));
            }

            return await _context.StudentCourses.Where(x => x.StudentId == studentId).ToListAsync();
        }
        public async Task<IEnumerable<TeacherCourse>> GetCourseFromTeacherAsync(Guid teacherId)
        {
            if (teacherId == Guid.Empty)
            {
                throw new ArgumentException(nameof(teacherId));
            }

            return await _context.TeacherCourses.Where(x => x.TeacherId == teacherId).ToListAsync();
        }
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _context.Teachers.ToListAsync();
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<IEnumerable<Institute>> GetInstitutesAsync(IEnumerable<Guid> instituteIds)
        {
            if (instituteIds == null)
            {
                throw new ArgumentNullException(nameof(instituteIds));
            }

            return await _context.Institutes
                .Where(x => instituteIds.Contains(x.Id))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Teacher> GetTeacherAsync(Guid instituteId, Guid teacherId)
        {
            if (instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }
            if (teacherId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(teacherId));
            }

            return await _context.Teachers
                .Where(x => x.Id == teacherId && x.InstituteId == instituteId)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync(Guid instituteId)
        {
            if (instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }

            return await _context.Teachers
                .Where(x => x.InstituteId == instituteId)
                .OrderBy(x => x.TeacherNum)
                .ToListAsync();
        }

        public void UpdateInstitute(Institute institute)
        {
            //无需显式地声明
            //_context.Entry(institute).State = EntityState.Modified;
        }
        public void UpdateCourse(Course course)
        {

        }
        public void UpdateTeacher(Teacher teacher)
        {
            //无需显式地声明
            //_context.Entry(teacher).State = EntityState.Modified;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync(Guid instituteId)
        {
            if(instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }
            return await _context.Students
                .Where(x => x.InstituteId == instituteId)
                .OrderBy(x => x.StudentNum).ToListAsync();
        }

        public async Task<Student>GetStudentAsync(Guid instituteId, Guid studentId)
        {
            if(instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }
            if(studentId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Student));
            }
            return await _context.Students
                .Where(x => x.InstituteId == instituteId && x.Id == studentId).FirstOrDefaultAsync();
        }


        public void AddStudent(Guid instituteId, Student student)
        {
            if(instituteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(instituteId));
            }
            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            student.InstituteId = instituteId;
            _context.Students.Add(student);
        }
        public void UpdateStudent(Student student)
        {

        }
        public void DeleteStudent(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
