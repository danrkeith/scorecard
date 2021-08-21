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

        public SortedDictionary<int, int> GetRounds(int gameId, int team = 0)
        {
            SortedDictionary<int, int> rounds = new SortedDictionary<int, int>();

            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                com = SQLite.Command(
                    con,
                    @$"
                        SELECT round, score
                        FROM {_table}_hands
                        WHERE game_id = $g
                        AND team_id = $t
                    ",
                    ("$g", gameId),
                    ("$t", TeamIDs[team]));

                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception("3");
                    }

                    while (reader.Read())
                    {
                        int round = reader.GetInt32(0);
                        int score = reader.GetInt32(1);

                        // Only add score if it has not already been recorded
                        if (!rounds.Keys.Contains(round))
                        {
                            rounds.Add(round, score);
                        }
                    }
                }
            }

            return rounds;
        }

        public IActionResult BaseIndex() => View($"{_viewPath}/Index.cshtml");

        public IActionResult BaseDeleteRound(int round)
        {
            byte[] game;

            // Error Checking
            try
            {
                if (!HttpContext.Session.TryGetValue("game", out game))
                {
                    throw new Exception("1.2");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { RequestId = ex.Message });
            }

            // Open connection
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                // Get round id of round in correct position
                int roundId = GetRounds(BitConverter.ToInt32(game)).ElementAt(round).Key;

                // Delete from the current game the selected rounds
                com = SQLite.Command(
                    con,
                    @$"
                        DELETE FROM {_table}_hands
                        WHERE game_id = $g
                        AND round = $r
                    ",
                    ("$g", BitConverter.ToInt32(game)),
                    ("$r", roundId));

                com.ExecuteNonQuery();
            }

            return RedirectToAction("Game", _controller);
        }
    }
}
