using JokeAPI.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokeAPI.Models
{
    public class QuestionAnswer : IJoke
    {
        public QuestionAnswer()
        {
        }

        public QuestionAnswer(Joke joke)
        {
            this.Question = JsonConvert.DeserializeObject<QuestionAnswer>(joke.JokeText).Question;
            this.Answer = JsonConvert.DeserializeObject<QuestionAnswer>(joke.JokeText).Answer;
        }

        public QuestionAnswer(string question, string answer)
        {
            this.Question = question;
            this.Answer = answer;
        }

        public string Question { get; set; }
        public string Answer { get; set; }

        public bool Add(string joke)
        {
            throw new NotImplementedException();
        }

        public string Ask(string jokeStart)
        {
            if(Question == jokeStart)
            {
                return Answer;
            }
            else
            {
                return null;
            }
        }

        public string Display()
        {
            var converted = JsonConvert.SerializeObject(this);

            return converted;
        }
    }
}
