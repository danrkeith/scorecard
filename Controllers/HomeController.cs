using Microsoft.AspNetCore.Mvc;
using ScoreCardv2.Models;
using System;
using System.Diagnostics;

namespace ScoreCardv2.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            HttpContext.Session.Set("id", BitConverter.GetBytes(1));
            return View("/Views/Home/Index.cshtml");
        }

#nullable enable
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string? RequestId = null)
        {
            return View("/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = RequestId ?? (Activity.Current?.Id ?? HttpContext.TraceIdentifier) });
        }
#nullable disable
    }
}
