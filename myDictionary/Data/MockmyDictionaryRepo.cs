using System.Collections.Generic;
using myDictionary.Models;


namespace myDictionary.Data
{
    public class MockmyDictionaryRepo : ImyDictionaryRepo
    {
        public void CreateWord(Word word)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Word> GetAllWords()
        {
            var words = new List<Word>
            {
                new Word(0, "alighe", "for real"),
                new Word(1, "bet", "okay cool"),
                new Word(2, "say less", "for sure / down")
            };

            return words;
        }

        public Word GetWordById(int id)
        {
            return new Word(0, "alighe", "For REAL");

            
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}