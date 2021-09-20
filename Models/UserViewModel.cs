using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScoreCardv2.Models
{
    public class UserViewModel
    {
        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
    }
}
