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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;

namespace internetProgramming_TeemProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/institute")] 
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstituteRepository _instituteRepository;

        public TeachersController(IMapper mapper, IInstituteRepository instituteRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _instituteRepository = instituteRepository ?? throw new ArgumentNullException(nameof(instituteRepository));
        }
        [AllowAnonymous]
        [HttpGet("{instituteId}/teacher")]
        public async Task<ActionResult<TeacherDto>>
            GetTeachersForInstitute(Guid instituteId)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var teachers = await _instituteRepository.GetTeachersAsync(instituteId);

            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);

            return Ok(teacherDtos);
        }
        [AllowAnonymous]
        [HttpGet("{instituteId}/teacher/{teacherId}", Name = nameof(GetTeacherForInstitute))]  //还可用 [Route("{companyId}")]
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

        [HttpPost("{instituteId}/teacher")]
        public async Task<ActionResult<TeacherDto>>
            CreateTeacherForInstitute(Guid instituteId, TeacherAddDto teacher)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var entity = _mapper.Map<Teacher>(teacher);
            _instituteRepository.AddTeacher(instituteId, entity);
            await _instituteRepository.SaveAsync();

            var dtoToReturn = _mapper.Map<TeacherDto>(entity);

            return CreatedAtRoute(nameof(GetTeacherForInstitute), new {
                instituteId,
                teacherId = dtoToReturn.Id
            }, dtoToReturn);
        }

        [HttpPatch("{instituteId}/teacher/{teacherId}")]
        public async Task<IActionResult>PartiallyUpdateTeacherForInstitute(
            Guid instituteId, 
            Guid teacherId, 
            JsonPatchDocument<TeacherUpdateDto>patchDocument)
        {
            if(!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var teacherEntity = await _instituteRepository.GetTeacherAsync(instituteId, teacherId);

            if(teacherEntity == null)
            {
                return  NotFound();
            }

            var dtoToPatch = _mapper.Map<TeacherUpdateDto>(teacherEntity);
            //entity 转化为 updateDto
            //把传进来的teacher的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, teacherEntity);
            _instituteRepository.UpdateTeacher(teacherEntity);
            await _instituteRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{instituteId}/teacher/{teacherId}")]
        public async Task<IActionResult>DeleteTeacherForInstitute(Guid instituteId, Guid teacherId)
        {
            if(!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }

            var teacherEntity = await _instituteRepository.GetTeacherAsync(instituteId, teacherId);

            if(teacherEntity == null) 
            {
                return NotFound();
            }
            _instituteRepository.DeleteTeacher(teacherEntity);

            await _instituteRepository.SaveAsync();

            return NoContent();
        }
        [AllowAnonymous]
        [HttpGet("allTeacher")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var teachers = await _instituteRepository.GetAllTeachersAsync();

            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);

            return Ok(teacherDtos);  //OK() 返回状态码200
        }

        [HttpGet("teacher/{teacherNum}")]
        public async Task<ActionResult<TeacherDto>>
    GetTeacherForInstitute(string teacherNum)
        {
            var teacher = await _instituteRepository.GetTeacherNumAsync(teacherNum);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            return Ok(teacherDto);
        }
        [AllowAnonymous]
        [HttpGet("teacher/{teacherId}/courses")]
        public async Task<IActionResult> GetCourseFromTeacher(Guid teacherId)
        {
            var courses = await _instituteRepository.GetCourseFromTeacherAsync(teacherId);

            var CourseTeacherDtos = _mapper.Map<IEnumerable<TeacherCourseDto>>(courses);

            return Ok(CourseTeacherDtos);
        }
        [HttpOptions]
        public IActionResult GetStudentsOptions()
        {
            Response.Headers.Add("Allowss", "DELETE,GET,PATCH,PUT,OPTIONS");
            return Ok();
        }
    }
}
