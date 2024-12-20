using TimpieTyper.Core.Domain;
using TimpieTyper.Core.Interfaces;

namespace TimpieTyper.Core.Services;

public class WordService
{
    private readonly IWordRepository _wordRepository;

    public WordService(IWordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public List<Word> GetAll()
    {
        return _wordRepository.GetAll();
    }

    public Word GetById(int id)
    {
        return _wordRepository.GetById(id);
    }

    public List<Word> GetRandom(int count)
    {
        return _wordRepository.GetRandom(count);
    }

    public Word Create(Word word)
    {
        return _wordRepository.Create(word);
    }
}