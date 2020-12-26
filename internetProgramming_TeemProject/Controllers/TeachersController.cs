using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using internetProgramming_TeemProject.Data;
using internetProgramming_TeemProject.Services;
using internetProgramming_TeemProject.Entities;
using internetProgramming_TeemProject.Models;

namespace internetProgramming_TeemProject.Controllers
{
    [ApiController]
    [Route("api/institute/{instituteId}/teacher")]
    public class TeachersController :ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstituteRepository _instituteRepository;

        public TeachersController(IMapper mapper, IInstituteRepository instituteRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _instituteRepository = instituteRepository ?? throw new ArgumentNullException(nameof(instituteRepository));
        }

        [HttpGet]
        public async Task<ActionResult<TeacherDto>>
            GetTeachersForInstitute(Guid instituteId)
        {
            if(! await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var teachers = await _instituteRepository.GetTeachersAsync(instituteId);

            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);

            return Ok(teacherDtos);
        }

        [HttpGet("{teacherId}", Name = nameof(GetTeacherForInstitute))]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<TeacherDto>>
            GetTeacherForInstitute(Guid teacherId, Guid instituteId)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var teacher = await _instituteRepository.GetTeacherAsync(instituteId, teacherId);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return Ok(teacherDto);
        }

        [HttpPost]
        public async Task<ActionResult<TeacherDto>>
            CreateTeacherForInstitute(Guid instituteId, TeacherAddDto teacher)
        {
            if(!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var entity = _mapper.Map<Teacher>(teacher);
            _instituteRepository.AddTeacher(instituteId, entity);
            await _instituteRepository.SaveAsync();

            var dtoToReturn = _mapper.Map<TeacherDto>(entity);

            return CreatedAtRoute(nameof(GetTeacherForInstitute),new {
                    instituteId,
                    teacherId = dtoToReturn.Id
                },dtoToReturn);

        }
    }
}
