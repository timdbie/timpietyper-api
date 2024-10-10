using TimpieTyper.Core.Entities;
using TimpieTyper.Core.Interfaces;

namespace TimpieTyper.Core.Services;

public class WordService
{
    private readonly IWordRepository _wordRepository;

    public WordService(IWordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public Word Get()
    {
        return _wordRepository.Get();
    }

    public List<Word> GetByCount(int count)
    {
        return _wordRepository.GetByCount(count);
    }
}