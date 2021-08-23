using Microsoft.AspNetCore.Mvc;
using ScoreCardv2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Controllers
{
    public class BlankGameController : GameController<GameViewModel>
    {
        public BlankGameController() : base(
            viewPath: "Views/BlankGame",
            table: "blankGame",
            controller: "BlankGame",
            title: "Blank Game")
        { }

        [Route("/BlankGame/")]
        [HttpGet]
        public IActionResult Index() => BaseIndex();
    }
}
