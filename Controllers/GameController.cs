using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using ScoreCardv2.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Controllers
{
    public class GameController<TViewModel> : Controller where TViewModel : GameViewModel, new()
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

        public IActionResult BaseGame()
        {
            // Session variables
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


            // Create game data in model
            TViewModel model = new TViewModel();

            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                // Get names of team members
                com = SQLite.Command(
                    con,
                    @$"
                        SELECT t.id, p.name
                        FROM people p 
                        INNER JOIN (
                            SELECT *
                            FROM teams
                            WHERE id IN (
                                SELECT team_id
                                FROM teamGames
                                WHERE id IN (
                                    SELECT teamGame_id
                                    FROM {_table}_games
                                    WHERE id = $id
                                )
                            )
                        ) t ON p.id = t.person_id
                    ",
                    ("$id", BitConverter.ToInt32(game)));

                // Insert names into teams
                Dictionary<int, List<string>> teams = new Dictionary<int, List<string>>();

                using (SqliteDataReader reader = com.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0) - 1;

                        // Add team if it doesn't exist
                        if (!teams.ContainsKey(id))
                        {
                            teams.Add(id, new List<string>());
                        }

                        teams[id].Add(reader.GetString(1));
                    }
                }

                // Move teams to models
                model.Teams = new GameViewModel.Team[teams.Count()];

                for (int t = 0; t < teams.Count(); t++)
                {
                    model.Teams[t].Members = new string[teams.First().Value.Count()];

                    // Add names to team
                    for (int p = 0; p < teams.First().Value.Count(); p++)
                    {
                        model.Teams[t].Members[p] = teams.ElementAt(t).Value[p];
                    }
                }

                // Find each team's hand & catch if there are no current existing hands
                try
                {
                    for (int t = 0; t < teams.Count(); t++)
                    {
                        SortedDictionary<int, int> rounds = GetRounds(BitConverter.ToInt32(game), t);

                        // Create rounds array in model and store rounds
                        model.Teams[t].Rounds = rounds.Values.ToArray();

                        // Set round in session to 1 higher than the highest round
                        HttpContext.Session.Set("round", BitConverter.GetBytes(rounds.Keys.Max() + 1));
                    }
                }
                catch (Exception ex) when (ex.Message == "3")
                {
                    HttpContext.Session.Set("round", BitConverter.GetBytes(0));
                }
            }

            return View($"{_viewPath}/Game.cshtml", model);
        }

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
