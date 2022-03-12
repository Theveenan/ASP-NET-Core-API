using Microsoft.AspNetCore.Mvc;
using myDictionary.Models;
using myDictionary.Data;
using System.Collections.Generic;
using AutoMapper;
using myDictionary.Dtos;
using Microsoft.AspNetCore.JsonPatch;

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
        [HttpGet("{id}", Name="GetWordById")]
        public ActionResult <WordReadDto> GetWordById(int id)
        {
            var wordItem = _repository.GetWordById(id);
            if(wordItem != null)
            {
                return Ok(_mapper.Map<WordReadDto>(wordItem));
            }
            return NotFound();
        }

        //Post api/words
        [HttpPost]
        public ActionResult <WordReadDto> CreateWord(WordCreateDto wordCreateDto)
        {
            var wordModel = _mapper.Map<Word>(wordCreateDto);
            _repository.CreateWord(wordModel);
            _repository.SaveChanges();

            var wordReadTo = _mapper.Map<WordReadDto>(wordModel);

            return CreatedAtRoute(nameof(GetWordById), new {Id = wordReadTo.Id}, wordReadTo); 
            //return Ok(wordReadTo);
        }

        //PUT api/words/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateWord(int id, WordUpdateDto wordUpdateDto)
        {
            var wordModelFromRepo = _repository.GetWordById(id);
            if(wordModelFromRepo == null){
                return NotFound();
            }

            _mapper.Map(wordUpdateDto, wordModelFromRepo);

            //Tutorial put this in as "Good Practice" for other implementations if we were to ever switch
            //Although its "counter intuitive" and unneeded when considering just sticking with SQL implementation
           // _repository.UpdateWord(wordModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/words/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialWordUpdate(int id, JsonPatchDocument<WordUpdateDto> patchDoc)
        {
            var wordModelFromRepo = _repository.GetWordById(id);
            if(wordModelFromRepo == null)
            {
                return NotFound();
            }
        

            var wordToPatch = _mapper.Map<WordUpdateDto>(wordModelFromRepo);
            patchDoc.ApplyTo(wordToPatch, ModelState);
            if(!TryValidateModel(wordToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(wordToPatch, wordModelFromRepo);

            
            //Tutorial put this in as "Good Practice" for other implementations if we were to ever switch
            //Although its "counter intuitive" and unneeded when considering just sticking with SQL implementation
            // _repository.UpdateWord(wordModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/words/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteWord(int id)
        {
            var wordModelFromRepo = _repository.GetWordById(id);
            if(wordModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteWord(wordModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}