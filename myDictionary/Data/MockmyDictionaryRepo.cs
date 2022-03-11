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
                new Word{Id=0, Term="alighe", Description="for realll"},
                //new Word(0, "alighe", "for real"),
                new Word{Id=1, Term="bet", Description="okay cool"},
                //new Word(1, "bet", "okay cool"),
                new Word{Id=2, Term="say less", Description="for sure / down"}
                //new Word(2, "say less", "for sure / down")
            };

            return words;
        }

        public Word GetWordById(int id)
        {
            return new Word{Id=0, Term="alighe", Description="for realll"};
            //return new Word(0, "alighe", "For REAL");

            
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}