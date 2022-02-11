using System.Collections.Generic;
using myDictionary.Models;

namespace myDictionary.Data
{
    public interface ImyDictionaryRepo
    {
        IEnumerable<Word> GetAllWords();
        
        Word GetWordById(int id);
    }
}