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
    public class BlankGameController : GameController<BlankGameViewModel>
    {
        public BlankGameController() : base(
            viewPath: "Views/BlankGame",
            table: "blankGame",
            controller: "BlankGame")
        { }

        [Route("/BlankGame/")]
        [HttpGet]
        public IActionResult Index() => BaseIndex();

        [Route("/BlankGame/")]
        [HttpPost]
        public IActionResult PostIndex(TeamsViewModel model) => BasePostIndex(model);

        [Route("/BlankGame/Game/")]
        [HttpGet]
        public IActionResult Game() => BaseGame(null, false);

        [Route("/BlankGame/Game/")]
        [HttpPost]
        public IActionResult PostGame(BlankGameViewModel model)
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

                for (int t = 0; t < model.Scores.Length; t++)
                {
                    com = SQLite.Command(
                        con,
                        @"
                            INSERT INTO blankGame_hands (game_id, team_id, round, score)
                            VALUES ($g, $t, $r, $s)
                        ",
                        ("$g", BitConverter.ToInt32(game)),
                        ("$t", TeamIDs[t]),
                        ("$r", BitConverter.ToInt32(round)),
                        ("$s", model.Scores[t]));

                    com.ExecuteNonQuery();
                }
            }

            // Progress to next round
            HttpContext.Session.Set("round", BitConverter.GetBytes(BitConverter.ToInt32(round) + 1));

            return RedirectToAction("Game", "BlankGame");
        }

        [Route("/BlankGame/Game/DeleteRound/")]
        [HttpPost]
        public IActionResult DeleteRound(int round) => BaseDeleteRound(round);

        [Route("/BlankGame/Game/ToggleCompletion/")]
        [HttpGet]
        public IActionResult ToggleCompletion() => BaseToggleCompletion();

        [Route("/BlankGame/Resume/")]
        [HttpGet]
        public IActionResult Resume() => BaseResume();
    }
}
