using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Interfaces
{
    interface IJoke
    {
        string Ask(string jokeStart);
        string Display();
    }
}
