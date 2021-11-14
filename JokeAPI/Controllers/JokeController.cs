using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using JokeAPI.Models;
using JokeAPI.Data;
using System;
using System.Net;
using System.Net.Http;
using JokeAPI.Enums;
using JokeAPI.Interfaces;
using System.Collections.Generic;

namespace JokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly JokesContext _context;
        private readonly int InternalServerError = 500;

        public JokeController(JokesContext context)
        {
            _context = context;
        }

        // GET: JokeController
        [HttpGet]
        public IActionResult Index()
        {
            IJoke joke;
            var list = _context.Jokes.ToList();

            var item = list.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            if (item.JokeType == (int)JokeTypeEnum.LongForm)
            {
                //var jokeText = JsonConvert.DeserializeObject<LongForm>(item.JokeText).WholeJoke;
                joke = new LongForm(item);
            }
            else if (item.JokeType == (int)JokeTypeEnum.QuestionAnswer)
            {
                joke = new QuestionAnswer(item);
            }
            else
            {
                return NoContent();
            }

            var jokeToDisplay = joke.Display();

            return Ok(jokeToDisplay);
        }

        // GET: JokeController/Longform
        [HttpGet]
        [Route("LongForm")]
        public IActionResult LongForm()
        {
            IJoke joke;
            var list = _context.Jokes.ToList();

            var randomjoke = list.Where(j => j.JokeType == (int)JokeTypeEnum.LongForm).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            string jokeText = JsonConvert.DeserializeObject<LongForm>(randomjoke.JokeText).WholeJoke;
            joke = new LongForm(jokeText);

            var converted = JsonConvert.SerializeObject(joke);

            return Ok(joke.Display());
        }

        // GET: JokeController/QuestionAnswer
        [HttpGet]
        [Route("QuestionAnswer")]
        public IActionResult QuestionAnswer()
        {
            IJoke joke;
            var list = _context.Jokes.ToList();

            var randomjoke = list.Where(j => j.JokeType == (int)JokeTypeEnum.QuestionAnswer).OrderBy(x => Guid.NewGuid()).FirstOrDefault();

            var question = JsonConvert.DeserializeObject<QuestionAnswer>(randomjoke.JokeText).Question;
            var answer = JsonConvert.DeserializeObject<QuestionAnswer>(randomjoke.JokeText).Answer;
            joke = new QuestionAnswer(question, answer);


            return Ok(joke.Display());
        }

        // POST: JokeController/QuestionAnswer
        [HttpPost]
        [Route("QuestionAnswer")]
        public IActionResult QuestionAnswer(QuestionAnswer questionAnswer)
        {
            var convertToJSON = JsonConvert.SerializeObject(questionAnswer);

            Joke joke = new Joke()
            {
                JokeText = convertToJSON,
                JokeType = (int)JokeTypeEnum.QuestionAnswer
            };

            _context.Jokes.Add(joke);

            var completed = _context.SaveChanges();

            if (completed > 0)
            {
                return Ok("Joke has been added.");
            }
            else
            {
                return StatusCode(InternalServerError);
            }
        }

        // POST: JokeController/LongForm
        [HttpPost]
        [Route("LongForm")]
        public IActionResult LongForm(LongForm longForm)
        {
            var convertToJSON = JsonConvert.SerializeObject(longForm);

            Joke joke = new Joke()
            {
                JokeText = convertToJSON,
                JokeType = (int)JokeTypeEnum.LongForm
            };

            _context.Jokes.Add(joke);

            var completed = _context.SaveChanges();

            if (completed > 0)
            {
                return Ok("Joke has been added.");
            }
            else
            {
                return StatusCode(InternalServerError);
            }

        }

        // POST: JokeController/Question
        [HttpPost]
        [Route("Question")]
        public IActionResult Question(string question)
        {
            IJoke joke;
            List<IJoke> jokesList = new List<IJoke>();

            var list = _context.Jokes.ToList();

            foreach(var dbJoke in list)
            {
                if (dbJoke.JokeType == (int)JokeTypeEnum.LongForm)
                {
                    joke = new LongForm(dbJoke);
                }
                else if (dbJoke.JokeType == (int)JokeTypeEnum.QuestionAnswer)
                {
                    joke = new QuestionAnswer(dbJoke);
                }
                else
                {
                    break;
                }

                jokesList.Add(joke);
            }

            foreach(var askingJoke in jokesList)
            {
                var foundAnswer = askingJoke.Ask(question);

                if(!string.IsNullOrEmpty(foundAnswer))
                {
                    return Ok(foundAnswer);
                }
            }

            return NoContent();

        }
    }
}
