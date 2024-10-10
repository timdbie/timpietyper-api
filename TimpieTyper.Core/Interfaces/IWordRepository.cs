using TimpieTyper.Core.Entities;

namespace TimpieTyper.Core.Interfaces;

public interface IWordRepository
{
    List<Word> GetAll();
    Word GetById(int id);
    Word Create(Word word);
}