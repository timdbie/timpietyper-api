using Microsoft.AspNetCore.Mvc;
using TimpieTyper.Api.Dtos;
using TimpieTyper.Core.Services;

namespace TimpieTyper.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordController : ControllerBase
{
    private readonly WordService _wordService;

    public WordController(WordService wordService)
    {
        _wordService = wordService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var words = _wordService.GetAll();
        
        return Ok(WordsDto.FromEntity(words));
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var word = _wordService.GetById(id);
    
        return Ok(WordsDto.FromEntity(word));
    }

    [HttpGet("random")]
    public IActionResult GetRandom([FromQuery]int count = 50)
    {
        var words = _wordService.GetRandom(count);

        return Ok(WordsDto.FromEntity(words));
    }
    
    [HttpPost]
    public IActionResult Post(CreateWordDto createWordDto)
    {
        var word = CreateWordDto.ToWord(createWordDto);
        
        var createdWord = _wordService.Create(word);
        
        var wordsDto = WordsDto.FromEntity(createdWord);
        
        return CreatedAtAction(nameof(Get), new { id = createdWord.Id }, wordsDto);
    }
}