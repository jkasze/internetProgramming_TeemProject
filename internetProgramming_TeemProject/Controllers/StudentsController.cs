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
    public class StudentsController : ControllerBase
    {
        [ApiController]
        [Route("api/institute/{instituteId}/student")]
    }
}
