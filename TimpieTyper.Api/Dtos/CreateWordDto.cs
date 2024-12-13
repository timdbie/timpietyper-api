using TimpieTyper.Core.Domain;

namespace TimpieTyper.Api.Dtos
{
    public class CreateWordDto
    {
        public required string Value { get; set; }

        public static Word ToWord(CreateWordDto word)
        {
            return new Word(word.Value);
        }
    }
}