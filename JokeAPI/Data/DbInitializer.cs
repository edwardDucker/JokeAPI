using JokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(JokesContext context)
        {
            context.Database.EnsureCreated();

            if (context.Jokes.Any())
            {
                return;
            }

            Joke[] jokes = new Joke[]
            {
                new Joke() { JokeText = "{ \"WholeJoke\":\"The advantages of easy origami are two-fold\"}", JokeType = 1 },
                new Joke() { JokeText = "{ \"WholeJoke\":\"I've decided to sell my vacuum cleaner – it was just collecting dust.\"}", JokeType = 1 },
                new Joke() { JokeText = "{ \"WholeJoke\":\"The other day someone left a piece of Play Doh on my desk. I didn't know what to make of it.\"}", JokeType = 1 },
                new Joke() { JokeText = "{ \"WholeJoke\":\"You know, somebody actually complimented me on my driving today. They left a little note on the windscreen, it said 'Parking Fine.' So that was nice.\"}", JokeType = 1 },
                new Joke() { JokeText = "{ \"WholeJoke\":\"I was reading this book today, The History Of Glue and I couldn't put it down.\"}", JokeType = 1 },
                new Joke() { JokeText = "{ \"Question\":\"What's an astronaut’s favorite part of a computer?\",\"Answer\":\"The space bar.\"}", JokeType = 2 },
                new Joke() { JokeText = "{ \"Question\":\"Why are elevator jokes so good?\",\"Answer\":\"They work on many levels.\"}", JokeType = 2 },
                new Joke() { JokeText = "{ \"Question\":\"Whats orange and sounds like a parrot?\",\"Answer\":\"A Carrot\"}", JokeType = 2 },
                new Joke() { JokeText = "{ \"Question\":\"What's red a smells like blue paint?\",\"Answer\":\"Red Paint\"}", JokeType = 2 },
                new Joke() { JokeText = "{ \"Question\":\"Thanks for telling me the definition of the word many.\",\"Answer\":\"It means a lot\"}", JokeType = 2 }
            };
            foreach (var j in jokes)
            {
                context.Jokes.Add(j);
            }

            context.SaveChanges();
        }
    }
}
