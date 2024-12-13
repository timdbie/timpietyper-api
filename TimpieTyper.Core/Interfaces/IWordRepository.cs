using TimpieTyper.Core.Domain;

namespace TimpieTyper.Core.Interfaces;

public interface IWordRepository
{
    List<Word> GetAll();
    Word GetById(int id);
    List<Word> GetRandom(int count);
    Word Create(Word word);
}