using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using ScoreCardv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            // Open connection with SQLite database
            using (SqliteConnection con = new SqliteConnection("Data Source=Data.db"))
            {
                SQLitePCL.Batteries.Init();
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
                        ViewBag.Warning = "Username Taken";
                        return Register();
                    }
                }

                // Insert user into database, encrypting password and returning id
                using (SqliteTransaction transaction = con.BeginTransaction())
                {
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

                    // Get last inserted user
                    com = SQLite.Command(
                        con,
                        @"
                            SELECT MAX(id)
                            FROM users
                        ");

                    using (SqliteDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();

                        // Store user id in session
                        HttpContext.Session.Set("id", BitConverter.GetBytes(reader.GetInt32(0)));
                    }

                    transaction.Commit();
                }
            }

            // Return to home page
            return Redirect("/");
        }
    }
}
