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

    public async Task<List<Word>> GetAsync(int count)
    {
        return await _wordRepository.GetAsync(count);
    }
}