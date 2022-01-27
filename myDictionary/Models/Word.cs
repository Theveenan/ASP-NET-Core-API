using System.ComponentModel.DataAnnotations;

namespace myDictionary.Models
{
    public class Word
    {
        
        public Word(int Id, string Term, string Description)
        {
            this.Id = Id;
            this.Term = Term;
            this.Description = Description;
        }

        [Key]
        [Required]
        public int Id {get; set;}
        
        [Required]
        public string Term {get; set;}

        [Required]
        public string Description {get; set;}
    }
}