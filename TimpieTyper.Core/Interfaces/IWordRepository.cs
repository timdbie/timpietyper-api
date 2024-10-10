using TimpieTyper.Core.Entities;

namespace TimpieTyper.Core.Interfaces;

public interface IWordRepository
{
    Word Get();
    List<Word> GetByCount(int count);
}