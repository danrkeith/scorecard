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
    public class FiveHundredController : GameController
    {
        public FiveHundredController() : base(route: "FiveHundred", table: "fiveHundred") { }

        [Route("/FiveHundred/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Views/FiveHundred/Index.cshtml");
        }

        [Route("/FiveHundred/")]
        [HttpPost]
        public IActionResult PostIndex(TeamsViewModel model)
        {
            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                // Save team ids
                int[] teamIDs = new int[model.TeamCount];

                // Iterate through teams, creating people involved and links to teams
                for (int t = 0; t < model.TeamCount; t++)
                {
                    // Record ids of players simultaneously, to use in case a team does not exist
                    int[] ids = new int[model.PlayerCount];

                    // Iterate through players, inserting into people and getting ids, eliminating teams that don't contain that player
                    for (int p = 0; p < model.PlayerCount; p++)
                    {
                        // Insert player into database if they don't already exist
                        com = SQLite.Command(
                            con,
                            @"
                                INSERT OR IGNORE INTO people (name)
                                VALUES ($n)
                            ",
                            ("$n", model.Names[t][p]));

                        com.ExecuteNonQuery();

                        // Get ID of player
                        com = SQLite.Command(
                            con,
                            @"
                                SELECT id
                                FROM people
                                WHERE name = $n
                                LIMIT 1
                            ",
                            ("$n", model.Names[t][p]));

                        
                        using (SqliteDataReader reader = com.ExecuteReader())
                        {
                            reader.Read();

                            ids[p] = reader.GetInt32(0);
                        }
                    }

                    // Create team if it doesn't already exist, store id
                    teamIDs[t] = SQLite.CreateStructure(
                        con,
                        "teams",
                        "person_id",
                        Array.ConvertAll(ids, Convert.ToString));
                }

                // Create teamGame, pointing to each team involved in the game
                int teamGame = SQLite.CreateStructure(
                    con,
                    "teamGames",
                    "team_id",
                    Array.ConvertAll(teamIDs, Convert.ToString));

                // Start transaction to ensure that the max id is the last game inserted
                using (SqliteTransaction transaction = con.BeginTransaction())
                {
                    // Create game, leaving user as null if no user is logged in
                    com = SQLite.Command(
                        con,
                        $@"
                            INSERT INTO fiveHundred_games (user_id, teamGame_id)
                            VALUES ($u, $t)
                        ",
                        ("$u", HttpContext.Session.TryGetValue("id", out byte[] id) ? BitConverter.ToInt32(id) : (int?)null),
                        ("$t", teamGame));

                    com.ExecuteNonQuery();

                    // Get id of game just inserted
                    com = SQLite.Command(
                        con,
                        @"
                            SELECT MAX (id)
                            FROM fiveHundred_games
                        ");

                    using (SqliteDataReader reader = com.ExecuteReader())
                    {
                        reader.Read();

                        // Save id of game for session
                        HttpContext.Session.Set("game", BitConverter.GetBytes(reader.GetInt32(0)));
                    }

                    // Commit transaction
                    transaction.Commit();
                }
            }

            return RedirectToAction("Game", "FiveHundred");
        }

        [Route("/FiveHundred/Game/")]
        [HttpGet]
        public IActionResult Game()
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
            FiveHundredViewModel model = new FiveHundredViewModel();

            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=data.db"))
            {
                Batteries.Init();
                con.Open();
                SqliteCommand com;

                // Get names of team members
                com = SQLite.Command(
                    con,
                    @"
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
                                    FROM fiveHundred_games
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
                for (int i = 0; i < teams.Count(); i++)
                {
                    model.Teams[i].Members = new string[teams.First().Value.Count()];

                    for (int j = 0; j < teams.First().Value.Count(); j++)
                    {
                        model.Teams[i].Members[j] = teams.ElementAt(i).Value[j];
                    }
                }

                // TODO: Get existing hands in game
                HttpContext.Session.Set("round", BitConverter.GetBytes(0));
            }

            return View("/Views/FiveHundred/Game.cshtml", model);
        }

        [Route("/FiveHundred/Game/")]
        [HttpPost]
        public IActionResult PostGame(FiveHundredViewModel model)
        {
            // Session Variables
            byte[] game, roundArr;

            // Error checking
            try
            {
                if (!HttpContext.Session.TryGetValue("game", out game))
                {
                    throw new Exception("1.2");
                }
                if (!HttpContext.Session.TryGetValue("round", out roundArr))
                {
                    throw new Exception("1.3");
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

                // Progress to next round
                int round = BitConverter.ToInt32(roundArr) + 1;
                HttpContext.Session.Set("round", BitConverter.GetBytes(round));

                // Iterate through teams, adding hands to game
                for (int t = 0; t < model.Teams.Length; t++)
                {
                    // Calculate score for hand
                    int score;

                    if (t == model.Bidder)
                    {
                        // Calculate for bidder
                        score = ((int)model.Suit[t] * 20) + ((int)model.Bid[t] * 100) - 560;
                    }
                    else
                    {
                        // Calculate for defender
                        score = (int)model.Defence[t] * 10;
                    }

                    com = SQLite.Command(
                        con,
                        @"
                            INSERT INTO fiveHundred_hands (game_id, team_id, round, score)
                            VALUES ($g, $t, $r, $s)
                        ",
                        ("$g", BitConverter.ToInt32(game)),
                        ("$t", TeamIDs[t]),
                        ("$r", round),
                        ("$s", score));

                    com.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Game", "FiveHundred");
        }
    }
}
