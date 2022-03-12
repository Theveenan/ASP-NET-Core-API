using AutoMapper;
using myDictionary.Dtos;
using myDictionary.Models;

namespace myDictionary.Profiles
{
    public class WordsProfile : Profile
    {

            public WordsProfile()
            {
                //       <Source -> Target>
                CreateMap<Models.Word, WordReadDto>();
                CreateMap<WordCreateDto, Models.Word>();
                CreateMap<WordUpdateDto, Models.Word>();
                CreateMap<Models.Word, WordUpdateDto>();
            }

    }

}