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
    public class FiveHundredController : Controller
    {
        [Route("/FiveHundred/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View("Views/FiveHundred/Index.cshtml");
        }

        [Route("/FiveHundred/")]
        [HttpPost]
        public void PostIndex(TeamsViewModel model)
        {
            // Open connection with database
            using (SqliteConnection con = new SqliteConnection("Data Source=Data.db"))
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
            }
        }
    }
}
