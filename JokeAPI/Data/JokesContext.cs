using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JokeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace JokeAPI.Data
{
    public class JokesContext : DbContext
    {
        public JokesContext(DbContextOptions<JokesContext> options) : base(options)
        {
        }

        public DbSet<Joke> Jokes { get; set; }
    }
}
