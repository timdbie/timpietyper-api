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
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var word = _wordService.GetById(id);
    
        return Ok(WordsDto.FromEntity(word));
    }

    [HttpPost]
    public IActionResult Post(CreateWordDto createWordDto)
    {
        var word = createWordDto.ToEntity();
        
        var createdWord = _wordService.Create(word);
        
        var wordsDto = WordsDto.FromEntity(createdWord);
        
        return CreatedAtAction(nameof(GetById), new { id = createdWord.Id }, wordsDto);
    }
}