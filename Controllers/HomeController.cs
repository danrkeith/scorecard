using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using ScoreCardv2.Models;
using SQLitePCL;
using System;
using System.Diagnostics;

namespace ScoreCardv2.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [HttpGet]
        public IActionResult Index(string warning = null)
        {
            byte[] id;
            UserViewModel model = new UserViewModel();

            // Check for logged in user
            if (HttpContext.Session.TryGetValue("id", out id))
            {
                // Open connection with database
                using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
                {
                    Batteries.Init();
                    con.Open();
                    SqliteCommand com;

                    com = SQLite.Command(
                        con,
                        @"
                            SELECT username
                            FROM users
                            WHERE id = $i
                        ",
                        ("$i", BitConverter.ToInt32(id)));

                    using (SqliteDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();

                        model.Username = reader.GetString(0);
                    }
                }
            }

            ViewBag.Warning = warning;
            return View("/Views/Home/Index.cshtml", model);
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
