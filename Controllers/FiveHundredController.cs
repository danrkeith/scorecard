using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Controllers
{
    public class FiveHundredController : Controller
    {
        [Route("/FiveHundred/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Views/FiveHundred/Index.cshtml");
        }
    }
}
