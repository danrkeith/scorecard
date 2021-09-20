using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using ScoreCardv2.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;

namespace ScoreCardv2.Controllers
{
    public class UserController : Controller
    {
        // ASP.NET App settings
        //  https://www.c-sharpcorner.com/article/reading-values-from-appsettings-json-in-asp-net-core/
        private readonly IConfiguration _iConfig;

        public UserController(IConfiguration iConfig)
        {
            _iConfig = iConfig;
        }

        [Route("/User/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("/Views/User/Index.cshtml");
        }

        [Route("/User/Login/")]
        [HttpGet]
        public IActionResult Login(string warning = null)
        {
            ViewBag.Warning = warning;
            return View("/Views/User/Login.cshtml");
        }

        [Route("/User/Login/")]
        [HttpPost]
        public IActionResult PostLogin(UserViewModel model)
        {
            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                // Find user's id with corresponding username and hash
                com = SQLite.Command(
                    con,
                    @"
                        SELECT id
                        FROM users
                        WHERE username = $u
                        AND hash = $h
                        LIMIT 1
                    ",
                    ("$u", model.Username),
                    ("$h", Encryption.EncryptString(
                        _iConfig.GetValue<string>("EncryptionKey"),
                        model.Password)));

                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    // If credentials don't match, alert user
                    if (!reader.HasRows)
                    {
                        return RedirectToAction("Login", "User", new { warning = "Invalid username and/or password" });
                    }

                    reader.Read();

                    // Store user id in session
                    HttpContext.Session.Set("id", BitConverter.GetBytes(reader.GetInt32(0)));
                }
            }

            // Remove current game as active game
            HttpContext.Session.Remove("game");

            // Return to home page
            return RedirectToAction("Index", "Home");
        }

        [Route("/User/Logout/")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("id");
            return RedirectToAction("Index", "Home");
        }

        [Route("/User/Register/")]
        [HttpGet]
        public IActionResult Register(string warning = null)
        {
            ViewBag.Warning = warning;
            return View("/Views/User/Register.cshtml");
        }

        [Route("/User/Register/")]
        [HttpPost]
        public IActionResult PostRegister(UserViewModel model)
        {
            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                // Check if username already exists
                com = SQLite.Command(
                    con,
                    @"
                        SELECT EXISTS (
                            SELECT *
                            FROM users
                            WHERE username = $u
                        )
                    ",
                    ("$u", model.Username));
                
                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    reader.Read();

                    if (reader.GetInt32(0) == 1)
                    {
                        return RedirectToAction("Register", "User", new { warning = "Username taken" });
                    }
                }

                // Insert into database
                com = SQLite.Command(
                    con,
                    @"
                        INSERT INTO users (username, hash)
                        VALUES ($u, $h)
                    ",
                    ("$u", model.Username),
                    ("$h", Encryption.EncryptString(
                        _iConfig.GetValue<string>("EncryptionKey"),
                        model.Password)));

                com.ExecuteNonQuery();
            }

            // Log user in
            return PostLogin(model);
        }

        [Route("/User/ChangePassword/")]
        [HttpGet]
        public IActionResult ChangePassword(string warning = null)
        {
            ViewBag.Warning = warning;
            return View("/Views/User/ChangePassword.cshtml");
        }

        [Route("/User/ChangePassword/")]
        [HttpPost]
        public IActionResult PostChangePassword(UserViewModel model)
        {
            byte[] id;

            // Error Checker
            try
            {
                if (!HttpContext.Session.TryGetValue("id", out id))
                {
                    throw new Exception("1.1");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { RequestId = ex.Message });
            }

            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                com = SQLite.Command(
                    con,
                    @"
                        SELECT hash
                        FROM users
                        WHERE id = $i
                    ",
                    ("$i", BitConverter.ToInt32(id)));

                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    reader.Read();

                    if (model.OldPassword != Encryption.DecryptString(_iConfig.GetValue<string>("EncryptionKey"), reader.GetString(0)))
                    {
                        return RedirectToAction("ChangePassword", "User", new { warning = "Current password is incorrect" });
                    }
                }

                com = SQLite.Command(
                    con,
                    @"
                        UPDATE users
                        SET hash = $h
                        WHERE id = $i
                    ",
                    ("$h", Encryption.EncryptString(_iConfig.GetValue<string>("EncryptionKey"), model.Password)),
                    ("$i", BitConverter.ToInt32(id)));

                com.ExecuteNonQuery();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
