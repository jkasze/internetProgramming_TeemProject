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
using Microsoft.AspNetCore.Authorization;

namespace internetProgramming_TeemProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/course")] //还可用 [Route("api/[controller]")]
    public class coursesController : ControllerBase
    {
        private readonly IInstituteRepository _courseRepository;
        private readonly IMapper _mapper;
        public coursesController(IInstituteRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository ??
                                        throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseRepository.GetCoursesAsync();


            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(courses);
    

            return Ok(courseDtos);  //OK() 返回状态码200
        }

        [HttpGet("{courseId}", Name = nameof(GetCourse))]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<CourseDto>> GetCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourseAsync(courseId);
            if (course == null)
            {
                return NotFound();  //返回状态码404
            }
            return Ok(_mapper.Map<CourseDto>(course));
        }
        [AllowAnonymous]
        [HttpGet("{courseId}/students")]
        public async Task<IActionResult> GetStudentFromCourse(Guid courseId)
        {
            var students = await _courseRepository.GetStudentFromCourseAsync(courseId);

            var CourseStudentDtos = _mapper.Map<IEnumerable<StudentCourseDto>>(students);

            return Ok(CourseStudentDtos);
        }
        [HttpPost]
        public async Task<ActionResult<CourseDto>> CreateCourse(CourseAddDto course)
        {
            var entity = _mapper.Map<Course>(course);
            _courseRepository.AddCourse(entity);
            await _courseRepository.SaveAsync();

            var returnDto = _mapper.Map<CourseDto>(entity);

            return CreatedAtRoute(nameof(GetCourse), new { courseId = returnDto.Id }, returnDto);
        }
        [HttpPatch("{courseId}")]
        public async Task<IActionResult> PartiallyUpdateAccount(
            Guid courseId,
            JsonPatchDocument<CourseUpdateDto> patchDocument)
        {
            var courseEntity = await _courseRepository.GetCourseAsync(courseId);

            if (courseEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<CourseUpdateDto>(courseEntity);
            //entity 转化为 updateDto
            //把传进来的Course的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, courseEntity);
            _courseRepository.UpdateCourse(courseEntity);
            await _courseRepository.SaveAsync();

            return NoContent();
        }
        
        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteCourse(Guid courseId)
        {
            var instututeEntity = await _courseRepository.GetCourseAsync(courseId);

            if (instututeEntity == null)
            {
                return NotFound();
            }

            _courseRepository.DeleteCourse(instututeEntity);

            await _courseRepository.SaveAsync();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCoursesOptions()
        {
            Response.Headers.Add("Allowss", "DELETE,GET,PATCH,PUT,OPTIONS");
            return Ok();
        }

    }
    [ApiController]
    [Route("api/course/{courseId}/lab")]
    public class coursesLabController : ControllerBase
    {
        private readonly IInstituteRepository _courseRepository;
        private readonly IMapper _mapper;
        public coursesLabController(IInstituteRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository ??
                                        throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<CourseLabDto>> GetCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourseAsync(courseId);
            if (course == null)
            {
                return NotFound();  //返回状态码404
            }
            return Ok(_mapper.Map<CourseLabDto>(course));
        }
        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdateCourse(
            Guid courseId,
            JsonPatchDocument<CourseLabUpdateDto> patchDocument)
        {
            var courseEntity = await _courseRepository.GetCourseAsync(courseId);

            if (courseEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<CourseLabUpdateDto>(courseEntity);
            //entity 转化为 updateDto
            //把传进来的Course的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, courseEntity);
            _courseRepository.UpdateCourse(courseEntity);
            await _courseRepository.SaveAsync();

            return NoContent();
        }
    }
    [ApiController]
    [Route("api/course/{courseId}/ex")]
    public class coursesExController : ControllerBase
    {
        private readonly IInstituteRepository _courseRepository;
        private readonly IMapper _mapper;
        public coursesExController(IInstituteRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository ??
                                        throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<CourseExDto>> GetCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourseAsync(courseId);
            if (course == null)
            {
                return NotFound();  //返回状态码404
            }
            return Ok(_mapper.Map<CourseExDto>(course));
        }

        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdateCourse(
            Guid courseId,
            JsonPatchDocument<CourseExUpdateDto> patchDocument)
        {
            var courseEntity = await _courseRepository.GetCourseAsync(courseId);

            if (courseEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<CourseExUpdateDto>(courseEntity);
            //entity 转化为 updateDto
            //把传进来的Course的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, courseEntity);
            _courseRepository.UpdateCourse(courseEntity);
            await _courseRepository.SaveAsync();

            return NoContent();
        }

    }
    [ApiController]
    [Route("api/course/{courseId}/PPT")]
    public class coursesPPTController : ControllerBase
    {
        private readonly IInstituteRepository _courseRepository;
        private readonly IMapper _mapper;
        public coursesPPTController(IInstituteRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository ??
                                        throw new ArgumentNullException(nameof(courseRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<CoursePPTDto>> GetCourse(Guid courseId)
        {
            var course = await _courseRepository.GetCourseAsync(courseId);
            if (course == null)
            {
                return NotFound();  //返回状态码404
            }
            return Ok(_mapper.Map<CoursePPTDto>(course));
        }
        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdateCourse(
            Guid courseId,
            JsonPatchDocument<CoursePPTUpdateDto> patchDocument)
        {
            var courseEntity = await _courseRepository.GetCourseAsync(courseId);

            if (courseEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<CoursePPTUpdateDto>(courseEntity);
            //entity 转化为 updateDto
            //把传进来的Course的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, courseEntity);
            _courseRepository.UpdateCourse(courseEntity);
            await _courseRepository.SaveAsync();

            return NoContent();
        }


    }

}