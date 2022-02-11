using Microsoft.EntityFrameworkCore;
using myDictionary.Models;

namespace myDictionary.Data
{
    
    public class myDictionaryContext : DbContext
    {
        public myDictionaryContext(DbContextOptions<myDictionaryContext> opt) : base(opt)
        {

        }

        public DbSet<Word> Words {get; set;}

    }
    
}