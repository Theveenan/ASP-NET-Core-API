namespace myDictionary.Dtos
{
    public class WordCreateDto
    {

        //Dont supply this as the Database is creating the ID, not the client user
        //public int Id {get; set;}
        
        public string Term {get; set;}

        public string Description {get; set;}
    }
}