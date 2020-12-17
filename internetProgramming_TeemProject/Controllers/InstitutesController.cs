using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using internetProgramming_TeemProject.Services;
using internetProgramming_TeemProject.Data;
using Microsoft.EntityFrameworkCore;

namespace internetProgramming_TeemProject.Controllers
{
    [ApiController]
    [Route("api/Institute")] //还可用 [Route("api/[controller]")]
    public class institutesController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;
        public institutesController(IInstituteRepository instituteRepository)
        {
            this._instituteRepository = instituteRepository ??
                                        throw new ArgumentNullException(nameof(instituteRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetInstitutes()
        {
            var companies = await _instituteRepository.GetInstitutesAsync();
            return Ok(companies);  //OK() 返回状态码200
        }

        [HttpGet("{instituteId}")]  //还可用 [Route("{companyId}")]
        public async Task<IActionResult> GetInstitute(Guid companyId)
        {
            var institute = await _instituteRepository.GetInstituteAsync(companyId);
            if (institute == null)
            {
                return NotFound();  //返回状态码404
            }
            return Ok(institute);
        }

    }
}
