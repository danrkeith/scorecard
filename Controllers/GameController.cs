using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Controllers
{
    public class GameController : Controller
    {
        private readonly string _viewPath;
        private readonly string _table;
        private readonly string _controller;
        public GameController(string viewPath, string table, string controller)
        {
            _viewPath = viewPath;
            _table = table;
            _controller = controller;
        }

        public int[] TeamIDs
        {
            get
            {
                if (!HttpContext.Session.TryGetValue("game", out byte[] game))
                {
                    throw new Exception("1.2");
                }

                using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
                {
                    Batteries.Init();
                    con.Open();
                    SqliteCommand com;

                    com = SQLite.Command(
                        con,
                        @$"
                            SELECT team_id
                            FROM teamGames
                            WHERE id IN (
                                SELECT teamGame_id
                                FROM {_table}_games
                                WHERE id = $id
                            )
                        ",
                        ("$id", BitConverter.ToInt32(game)));

                    List<int> ids = new List<int>();

                    using (SqliteDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ids.Add(reader.GetInt32(0));
                        }
                    }

                    return ids.ToArray();
                }
            }
        }

        public IActionResult BaseIndex() => View($"{_viewPath}/Index.cshtml");

        public IActionResult BaseDeleteRound(int round)
        {
            return RedirectToAction("Game", _controller);
        }
    }
}
