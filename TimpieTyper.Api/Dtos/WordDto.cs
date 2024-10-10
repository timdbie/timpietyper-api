using TimpieTyper.Core.Entities;

namespace TimpieTyper.Api.Dtos;

public class WordDto
{
    public required int Id { get; set; }
    public required string Value { get; set; }

    public static WordDto FromEntity (Word word)
    {
        return new WordDto()
        {
            Id = word.Id,
            Value = word.Value
        };
    }
}