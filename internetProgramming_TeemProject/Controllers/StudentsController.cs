using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internetProgramming_TeemProject.Services;
using internetProgramming_TeemProject.Data;
using Microsoft.EntityFrameworkCore;
using internetProgramming_TeemProject.Entities;
using internetProgramming_TeemProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace internetProgramming_TeemProject.Controllers
{
    [ApiController]
    [Route("api/institute")]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstituteRepository _instituteRepository;

        public StudentsController(IMapper mapper, IInstituteRepository instituteRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _instituteRepository = instituteRepository ?? throw new ArgumentNullException(nameof(instituteRepository));
        }

        [HttpGet("{instituteId}/student")]
        public async Task<ActionResult<StudentDto>>
            GetStudentsForInstitute(Guid instituteId)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var students = await _instituteRepository.GetStudentsAsync(instituteId);


            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return Ok(studentDtos);
        }

        [HttpGet("{instituteId}/student/{studentId}", Name = nameof(GetStudentForInstitute))]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<StudentDto>>
            GetStudentForInstitute(Guid studentId, Guid instituteId)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var student = await _instituteRepository.GetStudentAsync(instituteId, studentId);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost("{instituteId}/student")]
        public async Task<ActionResult<StudentDto>>
            CreateStudentForInstitute(Guid instituteId, StudentAddDto student)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var entity = _mapper.Map<Student>(student);
            _instituteRepository.AddStudent(instituteId, entity);
            await _instituteRepository.SaveAsync();

            var dtoToReturn = _mapper.Map<StudentDto>(entity);

            return CreatedAtRoute(nameof(GetStudentForInstitute), new
            {
                instituteId,
                studentId = dtoToReturn.Id
            }, dtoToReturn);
        }

        [HttpPatch("{instituteId}/student/{studentId}")]
        public async Task<IActionResult> PartiallyUpdateStudentForInstitute(
            Guid instituteId,
            Guid studentId,
            JsonPatchDocument<StudentUpdateDto> patchDocument)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }
            var studentEntity = await _instituteRepository.GetStudentAsync(instituteId, studentId);

            if (studentEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<StudentUpdateDto>(studentEntity);
            //entity 转化为 updateDto
            //把传进来的student的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, studentEntity);
            _instituteRepository.UpdateStudent(studentEntity);
            await _instituteRepository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{instituteId}/student/{studentId}")]
        public async Task<IActionResult> DeleteStudentForInstitute(Guid instituteId, Guid studentId)
        {
            if (!await _instituteRepository.InstituteExistsAsync(instituteId))
            {
                return NotFound();
            }

            var studentEntity = await _instituteRepository.GetStudentAsync(instituteId, studentId);

            if (studentEntity == null)
            {
                return NotFound();
            }
            _instituteRepository.DeleteStudent(studentEntity);

            await _instituteRepository.SaveAsync();

            return NoContent();
        }
        [HttpGet("allStudent")]
        public async Task<IActionResult> GetAllStudent()
        {
            var students = await _instituteRepository.GetAllStudentsAsync();

            var studentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return Ok(studentDtos);  //OK() 返回状态码200
        }
        [HttpOptions]
        public IActionResult GetStudentsOptions()
        {
            Response.Headers.Add("Allowss", "DELETE,GET,PATCH,PUT,OPTIONS");
            return Ok();
        }
    }
}
