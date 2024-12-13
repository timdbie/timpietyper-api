using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TimpieTyper.Core.Domain;

namespace TimpieTyper.Persistence.Entities
{
    [Table("Words")]
    public class WordEntity
    {
        [Required]
        public int Id { get; set; }
        public string Value { get; set; }
        
        public static Word ToWord(WordEntity entity)
        {
            return new Word(entity.Id, entity.Value);
        }

        public static WordEntity FromWord(Word word)
        {
            return new WordEntity()
            {
                Id = word.Id,      
                Value = word.Value 
            };
        }
    }
}