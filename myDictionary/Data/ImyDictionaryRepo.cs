using System.Collections.Generic;
using myDictionary.Models;

namespace myDictionary.Data
{
    public interface ImyDictionaryRepo
    {
        bool SaveChanges();

        IEnumerable<Word> GetAllWords();
        
        Word GetWordById(int id);

        void CreateWord(Word word);
    }
}