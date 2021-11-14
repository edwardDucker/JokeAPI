using JokeAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Models
{
    public class LongForm : IJoke
    {
        public LongForm()
        {
        }

        public LongForm(string wholeJoke)
        {
            WholeJoke = wholeJoke;
        }

        public LongForm(Joke dbJoke)
        {
            WholeJoke = JsonConvert.DeserializeObject<LongForm>(dbJoke.JokeText).WholeJoke;
        }

        public string WholeJoke { get; set; }

        public bool Add(string joke)
        {
            throw new NotImplementedException();
        }

        public string Ask(string jokeStart)
        {
            return null;
        }

        public string Display()
        {
            return WholeJoke;
        }
    }
}
