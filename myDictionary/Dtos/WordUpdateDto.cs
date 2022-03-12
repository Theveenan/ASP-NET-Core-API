using System.ComponentModel.DataAnnotations;

namespace myDictionary.Dtos
{
    public class WordUpdateDto
    {

        //Dont supply this as the Database is creating the ID, not the client user
        //public int Id {get; set;}
        
        [Required]
        public string Term {get; set;}

        [Required]
        public string Description {get; set;}
    }
}