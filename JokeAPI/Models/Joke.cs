using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Models
{
    public class Joke
    {
        public int JokeID { get; set; }
        public string JokeText { get; set; }
        public int JokeType { get; set; }
    }
}
