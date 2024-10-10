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

    public List<Word> GetAll()
    {
        return _wordRepository.GetAll();
    }

    public Word GetById(int id)
    {
        return _wordRepository.GetById(id);
    }

    public Word Create(Word word)
    {
        return _wordRepository.Create(word);
    }
}