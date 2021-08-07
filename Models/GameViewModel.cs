using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Models
{
    public class GameViewModel
    {
        public Team[] Teams { get; set; }
        public struct Team
        {
            public string[] Members { get; set; }
            public int[] Rounds { get; set; }
            
            public string Name => string.Join(", ", Members);
            public int Score => Rounds.Sum();
        }
    }
}
