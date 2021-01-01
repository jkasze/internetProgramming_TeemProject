using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using internetProgramming_TeemProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace internetProgramming_TeemProject.Controllers
{
    [Route("api")]
    [ApiController]
    public class authenticationController : ControllerBase
    {
        private readonly IInstituteRepository _instituteRepository;
        private readonly IMapper _mapper;

        private readonly IAuthenticateService _authService;
        public authenticationController(IAuthenticateService authService, IInstituteRepository instituteRepository, IMapper mapper)
        {
            this._authService = authService;
            this._instituteRepository = instituteRepository ??
                                        throw new ArgumentNullException(nameof(instituteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [AllowAnonymous]
        [HttpPost, Route("token")]
        public ActionResult RequestToken([FromBody] LoginRequestDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            var Entity = _instituteRepository.GetTokenAsync(request.Username, request.Password, request.Type).Result;

            if (Entity != null)
            {
                string token;
                if (_authService.IsAuthenticated(request, out token))
                {
                    return Ok(token);
                }
            }
            return BadRequest("Invalid Request");
        }

    }
}
