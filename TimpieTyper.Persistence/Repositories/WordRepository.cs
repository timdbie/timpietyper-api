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

    public Word Get()
    {
        return _context.Words.FirstOrDefault();
    }

    public List<Word> GetByCount(int count)
    {
        return _context.Words
            .Take(count)
            .ToList();
    }
}
