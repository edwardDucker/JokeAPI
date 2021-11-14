using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Interfaces
{
    interface IJoke
    {
        bool Add(string joke);
        string Ask(string jokeStart);
        string Display();
    }
}
