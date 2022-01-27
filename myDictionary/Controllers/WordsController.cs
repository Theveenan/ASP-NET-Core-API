using Microsoft.AspNetCore.Mvc;
using myDictionary.Models;
using myDictionary.Data;
using System.Collections.Generic;

namespace myDictionary.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly MockmyDictionaryRepo _repository = new MockmyDictionaryRepo();
        //GET api/words
        [HttpGet]
        public ActionResult <IEnumerable<Word>> GetAllWords()
        {
            var wordItems = _repository.GetAllWords();

            return Ok(wordItems);
        }

        //Get api/words/{id}
        [HttpGet("{id}")]
        public ActionResult <Word> GetWordById(int id)
        {
            var wordItem = _repository.GetWordById(id);

            return Ok(wordItem);
        }
    }
}