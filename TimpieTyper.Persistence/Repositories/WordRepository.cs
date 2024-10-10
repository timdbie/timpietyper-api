using Microsoft.EntityFrameworkCore;
using TimpieTyper.Core.Interfaces;
using TimpieTyper.Core.Entities;
using TimpieTyper.Persistence.Context;

namespace TimpieTyper.Persistence.Repositories;

public class WordRepository : IWordRepository
{
    private readonly AppDbContext _context;

    public WordRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Word> GetAll()
    {
        return _context.Words.ToList();
    }

    public Word GetById(int id)
    {
        return _context.Words.FirstOrDefault(word => word.Id == id);
    }

    public Word Create(Word word)
    {
        _context.Words.Add(word);
        _context.SaveChanges();
        return word;
    }
}
