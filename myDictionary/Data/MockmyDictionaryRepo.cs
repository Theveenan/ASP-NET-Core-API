namespace myDictionary.Data
{
    public class MockmyDictionaryRepo : ImyDictionaryRepo
    {
        PUBLIC IEnumerable<Word> GetWords()
        {
            var words = new List<word>
            {
                new Word(Id=0, word="alighe", description="for real"),
                new Word(Id=1, word="bet", description="okay cool"),
                new Word(Id=2, word="say less", description="for sure / down")
            };

            return words;
        }

        public Word GetWordById(int id)
        {
            return new Word(Id=0, word="alighe", description="For REAL");

            
        }
    }
}