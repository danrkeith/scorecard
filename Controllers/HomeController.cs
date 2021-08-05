using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScoreCardv2.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            //return View("/Views/Home/Index.cshtml");

            HttpContext.Session.Set("game", BitConverter.GetBytes(1));
            return RedirectToAction("Game", "FiveHundred");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
