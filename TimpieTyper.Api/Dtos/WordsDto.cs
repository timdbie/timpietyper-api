using TimpieTyper.Core.Domain;

namespace TimpieTyper.Api.Dtos;

public class WordsDto
{
    public List<string> Values { get; set; }

    public static WordsDto FromEntity(Word word)
    {
        return new WordsDto()
        {
            Values = [word.Value]
        };
    }
    
    public static WordsDto FromEntity (List<Word> words)
    {
        return new WordsDto()
        {
            Values = words.Select(word => word.Value).ToList()
        };
    }
}