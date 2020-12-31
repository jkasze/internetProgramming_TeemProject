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
    //[Authorize]
    [ApiController]
    [Route("api/account")] //还可用 [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IInstituteRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountController(IInstituteRepository instituteRepository, IMapper mapper)
        {
            this._accountRepository = instituteRepository ??
                                        throw new ArgumentNullException(nameof(instituteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPatch("{username}/{password}")]
        public async Task<IActionResult> PartiallyUpdateInstitute(
                    string username,
                    string password,
                    JsonPatchDocument<AccountUpdateDto> patchDocument)
        {
            var accountEntity = await _accountRepository.GetTokenAsync(username,password);

            if (accountEntity == null)
            {
                return NotFound();
            }

            var dtoToPatch = _mapper.Map<AccountUpdateDto>(accountEntity);
            //entity 转化为 updateDto
            //把传进来的account的值更新到updateDto
            //把updateDto映射回entity

            //需要处理验证错误
            patchDocument.ApplyTo(dtoToPatch);

            _mapper.Map(dtoToPatch, accountEntity);
            _accountRepository.UpdatePassword(accountEntity);
            await _accountRepository.SaveAsync();

            return NoContent();
        }
    }
}
