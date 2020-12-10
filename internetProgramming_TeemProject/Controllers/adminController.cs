using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace internetProgramming_TeemProject.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
