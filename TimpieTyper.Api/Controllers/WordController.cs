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
        var word = _wordService.Get();
        
        return Ok(WordDto.FromEntity(word));
    }
    
    [HttpGet("{count:int}")]
    public IActionResult Get(int count)
    {
        var words = _wordService.GetByCount(count);
        
        return Ok(words.Select(WordDto.FromEntity));
    }
}