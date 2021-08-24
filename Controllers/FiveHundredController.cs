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
    public class FiveHundredController : GameController<FiveHundredViewModel>
    {
        public FiveHundredController() : base(
            viewPath: "Views/FiveHundred", 
            table: "fiveHundred",
            controller: "FiveHundred",
            title: "Five Hundred")
        { }

        [Route("/FiveHundred/")]
        [HttpGet]
        public IActionResult Index() => BaseIndex();

        [Route("/FiveHundred/")]
        [HttpPost]
        public IActionResult PostIndex(TeamsViewModel model) => BasePostIndex(model);

        [Route("/FiveHundred/Game/")]
        [HttpGet]
        public IActionResult Game() => BaseGame();

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

        [Route("/FiveHundred/Game/DeleteRound")]
        [HttpPost]
        public IActionResult DeleteRound(int round) => BaseDeleteRound(round);
    }
}
