using Microsoft.AspNetCore.Mvc;
using myDictionary.Models;
using myDictionary.Data;
using System.Collections.Generic;
using AutoMapper;
using myDictionary.Dtos;

namespace myDictionary.Controllers
{
    [Route("api/words")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly ImyDictionaryRepo _repository;
        private readonly IMapper _mapper;
        
        public WordsController(ImyDictionaryRepo repository, IMapper mapper){
            _repository = repository;
            _mapper = mapper;

        }

        //private readonly MockmyDictionaryRepo _repository = new MockmyDictionaryRepo();

        //GET api/words
        [HttpGet]
        public ActionResult <IEnumerable<WordReadDto>> GetAllWords()
        {
            var wordItems = _repository.GetAllWords();

            return Ok(_mapper.Map<IEnumerable<WordReadDto>>(wordItems));
        }

        //Get api/words/{id}
        [HttpGet("{id}")]
        public ActionResult <WordReadDto> GetWordById(int id)
        {
            var wordItem = _repository.GetWordById(id);
            if(wordItem != null)
            {
                return Ok(_mapper.Map<WordReadDto>(wordItem));
            }
            return NotFound();
        }

        //Post api/commands
        [HttpPost]
        public ActionResult <WordReadDto> CreateWord(WordCreateDto WordCreateDto)
        {
            var wordModel = _mapper.Map<Word>(WordCreateDto);
            _repository.CreateWord(wordModel);

            return Ok(wordModel);
        }

    }
}