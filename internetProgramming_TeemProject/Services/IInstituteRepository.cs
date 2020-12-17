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
        Task<Institute> GetInstituteAsync(Guid instituteId);
        Task<IEnumerable<Institute>> GetInstitutesAsync(IEnumerable<Guid> instituteIds);
        void AddInstitute(Institute institute);
        void UpdateInstitute(Institute institute);
        void DeleteInstitute(Institute institute);
        Task<bool> InstituteExistsAsync(Guid instituteId);
        Task<IEnumerable<Teacher>> GetTeachersAsync(Guid instituteId);
        Task<Teacher> GetTeacherAsync(Guid instituteId, Guid teacherId);
        void AddTeacher(Guid instituteId, Teacher teacher);
        void UpdateTeacher(Teacher teacher);
        void DeleteTeacher(Teacher teacher);
        Task<bool> SaveAsync();
    }
}
