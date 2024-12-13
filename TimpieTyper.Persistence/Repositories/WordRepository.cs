using TimpieTyper.Core.Interfaces;
using TimpieTyper.Core.Domain;
using TimpieTyper.Persistence.Context;
using TimpieTyper.Persistence.Entities;

namespace TimpieTyper.Persistence.Repositories
{
    public class WordRepository : IWordRepository
    {
        private readonly AppDbContext _context;

        public WordRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Word> GetAll()
        {
            return _context.Words
                .Select(WordEntity.ToWord)
                .ToList();
        }

        public Word GetById(int id)
        {
            var entity = _context.Words.FirstOrDefault(word => word.Id == id);
            return entity != null ? WordEntity.ToWord(entity) : null;
        }

        public List<Word> GetRandom(int count)
        {
            var maxId = _context.Words.Max(w => w.Id);
            var randomWords = new List<Word>();
            var random = new Random();

            while (randomWords.Count < count)
            {
                var randomId = random.Next(1, maxId + 1);
                
                var randomEntity = _context.Words.Find(randomId);
                
                if (randomEntity != null)
                {
                    randomWords.Add(WordEntity.ToWord(randomEntity));
                }
            }
            return randomWords;
        }

        public Word Create(Word word)
        {
            var entity = WordEntity.FromWord(word);
            _context.Words.Add(entity);
            _context.SaveChanges();
            return WordEntity.ToWord(entity);
        }
    }
}