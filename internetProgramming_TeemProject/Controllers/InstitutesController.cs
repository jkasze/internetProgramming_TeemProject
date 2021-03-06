﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/institute")] //还可用 [Route("api/[controller]")]
    public class institutesController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;
        private readonly IMapper _mapper;
        public institutesController(IInstituteRepository instituteRepository, IMapper mapper)
        {
            this._instituteRepository = instituteRepository ??
                                        throw new ArgumentNullException(nameof(instituteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetInstitutes()
        {
            var institutes = await _instituteRepository.GetInstitutesAsync();

            var instituteDtos = _mapper.Map<IEnumerable<InstituteDto>>(institutes);

            return Ok(instituteDtos);  //OK() 返回状态码200
        }
        [AllowAnonymous]
        [HttpGet("{instituteId}", Name = nameof(GetInstitute))]  //还可用 [Route("{companyId}")]
        public async Task<ActionResult<InstituteDto>> GetInstitute(Guid instituteId)
        {
             var institute = await _instituteRepository.GetInstituteAsync(instituteId);
            if (institute == null)
            {
                return NotFound();  //返回状态码404
            }
            return Ok(_mapper.Map<InstituteDto>(institute));
        }
        [HttpPost]
        public async Task<ActionResult<InstituteDto>> CreateInstitute(InstituteAddDto institute)
        {
            var entity = _mapper.Map<Institute>(institute);
            _instituteRepository.AddInstitute(entity);
            await _instituteRepository.SaveAsync();

            var returnDto = _mapper.Map<InstituteDto>(entity);

            return CreatedAtRoute(nameof(GetInstitute),  new { instituteId = returnDto.Id }, returnDto);
        }
        [HttpPatch("{instituteId}")]
        public async Task<IActionResult> PartiallyUpdateInstitute(
            Guid instituteId,
            JsonPatchDocument<InstituteUpdateDto> patchDocument)
        {
            var instituteEntity = await _instituteRepository.GetInstituteAsync(instituteId);

            if (instituteEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<InstituteUpdateDto>(instituteEntity);
            //entity 转化为 updateDto
            //把传进来的Institute的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, instituteEntity);
            _instituteRepository.UpdateInstitute(instituteEntity);
            await _instituteRepository.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{instituteId}")]
        public async Task<IActionResult> DeleteInstitute(Guid instituteId)
        {
            var instututeEntity = await _instituteRepository.GetInstituteAsync(instituteId);

            if (instututeEntity == null)
            {
                return NotFound();
            }

            _instituteRepository.DeleteInstitute(instututeEntity);

            await _instituteRepository.SaveAsync();

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetInstitutesOptions()
        {
            Response.Headers.Add("Allowss", "DELETE,GET,PATCH,PUT,OPTIONS");
            return Ok();
        }

    }
}
