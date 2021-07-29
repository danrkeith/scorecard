using Microsoft.AspNetCore.Mvc;
using ScoreCardv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Controllers
{
    public class UserController : Controller
    {
        [Route("/User/")]
        public IActionResult Index()
        {
            return View("/Views/User/Index.cshtml");
        }

        [Route("/User/Login/")]
        public IActionResult Login()
        {
            return View("/Views/User/Login.cshtml");
        }

        [Route("/User/Register/")]
        [HttpGet]
        public IActionResult Register()
        {
            return View("/Views/User/Register.cshtml");
        }

        [Route("/User/Register/")]
        [HttpPost]
        public IActionResult PostRegister(UserViewModel model)
        {
            return Register();
        }
    }
}
