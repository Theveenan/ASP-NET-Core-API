using System.Collections.Generic;
using System.Linq;
using myDictionary.Models;

namespace myDictionary.Data
{
    public class SqlmyDictionaryRepo : ImyDictionaryRepo
    {
        private readonly myDictionaryContext _context;

        public SqlmyDictionaryRepo(myDictionaryContext context)
        {
            _context = context;
        }

        public IEnumerable<Word> GetAllWords()
        {
            return _context.Words.ToList();
        }

        public Word GetWordById(int id)
        {
            return _context.Words.FirstOrDefault(p => p.Id == id);
        }
    }
}