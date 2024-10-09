using TimpieTyper.Core.Entities;

namespace TimpieTyper.Core.Interfaces;

public interface IWordRepository
{
    Task<List<Word>> GetAsync(int count);
}