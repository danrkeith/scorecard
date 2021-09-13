using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Models
{
    public class LogViewModel
    {
        public GameType[] GameTypes { get; set; }
        public struct GameType
        {
            public string GameName { get; set; }
            public Game[] Games { get; set; }
            public struct Game
            {
                public bool Completed { get; set; }
                public string[] TeamNames { get; set; }
                public int[] Scores { get; set; }
            }
        }
    }
}
