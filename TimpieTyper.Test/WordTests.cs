using Moq;
using TimpieTyper.Core.Entities;
using TimpieTyper.Core.Interfaces;
using TimpieTyper.Core.Services;

namespace TimpieTyper.Test
{
    [TestFixture]
    public class WordServiceTests
    {
        private Mock<IWordRepository> _mockRepository;
        private WordService _wordService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IWordRepository>();
            _wordService = new WordService(_mockRepository.Object);
        }

        [Test]
        public void GetAll_ReturnsAllWords()
        {
            var expectedWords = new List<Word>
            {
                new Word { Id = 1, Value = "hello" },
                new Word { Id = 2, Value = "world" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(expectedWords);

            var result = _wordService.GetAll();
            
            Assert.That(result, Is.EqualTo(expectedWords));
            _mockRepository.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Test]
        public void GetById_ReturnsCorrectWord()
        {
            var expectedWord = new Word { Id = 1, Value = "that" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(expectedWord);
            
            var result = _wordService.GetById(1);
            
            Assert.That(result, Is.EqualTo(expectedWord));
            _mockRepository.Verify(repo => repo.GetById(1), Times.Once);
        }

        [Test]
        public void GetRandom_ReturnsCorrectNumberOfWords()
        {
            var expectedWords = new List<Word>
            {
                new Word { Id = 1, Value = "when" },
                new Word { Id = 2, Value = "from" },
                new Word { Id = 3, Value = "apple" }
            };
            _mockRepository.Setup(repo => repo.GetRandom(3)).Returns(expectedWords);
            
            var result = _wordService.GetRandom(3);
            
            Assert.That(result.Count, Is.EqualTo(3));
            _mockRepository.Verify(repo => repo.GetRandom(3), Times.Once);
        }

        [Test]
        public void Create_ReturnsCreatedWord()
        {
            var wordToCreate = new Word { Value = "word" };
            var createdWord = new Word { Id = 1, Value = "word" };
            _mockRepository.Setup(repo => repo.Create(wordToCreate)).Returns(createdWord);
            
            var result = _wordService.Create(wordToCreate);
            
            Assert.That(result, Is.EqualTo(createdWord));
            _mockRepository.Verify(repo => repo.Create(wordToCreate), Times.Once);
        }
    }
}