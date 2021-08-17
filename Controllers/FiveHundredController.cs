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
        public FiveHundredController() : base(
            route: "/FiveHundred", 
            viewPath: "Views/FiveHundred", 
            table: "fiveHundred")
        { }

        [Route("/FiveHundred/")]
        [HttpGet]
        public IActionResult Index() => BaseIndex();

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
                        for (int p = 0; p < teams.First().Value.Count(); p++)
                        {
                            // Get correct size of hands array
                            int maxRound = 0;

                            // Get hands
                            com = SQLite.Command(
                                con,
                                @"
                                    SELECT round, score
                                    FROM fiveHundred_hands
                                    WHERE game_id = $g
                                    AND team_id = $t
                                ",
                                ("$g", BitConverter.ToInt32(game)),
                                ("$t", TeamIDs[t]));

                            using (SqliteDataReader reader = com.ExecuteReader())
                            {
                                if (!reader.HasRows)
                                {
                                    throw new Exception("3");
                                }

                                while (reader.Read())
                                {
                                    if (reader.GetInt32(0) > maxRound)
                                    {
                                        maxRound = reader.GetInt32(0);
                                    }
                                }
                            }

                            // Create hands array
                            model.Teams[t].Hands = new int[maxRound + 1];

                            using (SqliteDataReader reader = com.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    model.Teams[t].Hands[reader.GetInt32(0)] = reader.GetInt32(1);
                                }
                            }

                            // Set round in session to first round not played
                            HttpContext.Session.Set("round", BitConverter.GetBytes(maxRound + 1));
                        }
                    }
                }
                catch (Exception ex) when (ex.Message == "3")
                {
                    HttpContext.Session.Set("round", BitConverter.GetBytes(0));
                }
            }

            return View("/Views/FiveHundred/Game.cshtml", model);
        }

        [Route("/FiveHundred/Game/")]
        [HttpPost]
        public IActionResult PostGame(FiveHundredViewModel model)
        {
            // Session Variables
            byte[] game, round;

            // Error checking
            try
            {
                if (!HttpContext.Session.TryGetValue("game", out game))
                {
                    throw new Exception("1.2");
                }
                if (!HttpContext.Session.TryGetValue("round", out round))
                {
                    throw new Exception("1.3");
                }

                // Throw error on missing bid only if a misere is not bid
                if ((model.Bid[model.Bidder] == null || model.Defence[model.Bidder] != null)
                    && !(model.Suit[model.Bidder] == 5 || model.Suit[model.Bidder] == 6))
                {
                    throw new Exception("2");
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

                // Iterate through teams, adding hands to game
                for (int t = 0; t < model.Bid.Length; t++)
                {
                    // Calculate score for hand
                    int score;

                    if (t == model.Bidder)
                    {
                        // Calculate for bidder
                        // Calculate tricks won
                        // Start at winning all 10 tricks, taking off tricks won by defence
                        int tricksWon = 10;
                        foreach (int? tricks in model.Defence)
                        {
                            tricksWon -= tricks ?? 0;
                        }

                        // Check for misere or open misere
                        if (model.Suit[t] == 5 || model.Suit[t] == 6)
                        {
                            score = model.Suit[t] == 5 ? 250 : 500;

                            // Turn points into loss if any tricks are won
                            if (tricksWon != 0)
                            {
                                score *= -1;
                            }
                        }
                        else
                        {
                            score = ((int)model.Suit[t] * 20) + ((int)model.Bid[t] * 100) - 560;

                            // Turn points into loss if tricks did not meet bid amount
                            if (tricksWon < model.Bid[t])
                            {
                                score *= -1;
                            }
                        }
                    }
                    else
                    {
                        // Calculate for defender if not misere; if it's a misere hand, defenders get no points.
                        score = model.Suit[model.Bidder] == 5 || model.Suit[model.Bidder] == 6 ? 0 : (int)model.Defence[t] * 10;
                    }

                    com = SQLite.Command(
                        con,
                        @"
                            INSERT INTO fiveHundred_hands (game_id, team_id, round, score)
                            VALUES ($g, $t, $r, $s)
                        ",
                        ("$g", BitConverter.ToInt32(game)),
                        ("$t", TeamIDs[t]),
                        ("$r", BitConverter.ToInt32(round)),
                        ("$s", score));

                    com.ExecuteNonQuery();
                }
            }

            // Progress to next round
            HttpContext.Session.Set("round", BitConverter.GetBytes(BitConverter.ToInt32(round) + 1));

            return RedirectToAction("Game", "FiveHundred");
        }
    }
}
