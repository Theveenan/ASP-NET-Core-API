namespace myDictionary.Data
{
    public interface ImyDictionaryRepo
    {
        IEnumerable<Word> GetWords();
        Word GetWordById(int id);
    }
}