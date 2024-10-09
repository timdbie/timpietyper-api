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

    public async Task<List<Word>> GetWordsAsync(int count)
    {
        return await _context.Words
            .OrderBy(w => Guid.NewGuid())
            .Take(count)
            .ToListAsync();
    }
}
