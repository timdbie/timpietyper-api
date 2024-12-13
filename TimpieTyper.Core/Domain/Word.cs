using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimpieTyper.Core.Domain
{
    public class Word
    {
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }
        
        public Word(int id, string value)
        {
            Id = id;
            Value = value;
        }

        public Word(string value)
        {
            Value = value;
        }
    }
}