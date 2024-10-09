using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetRandomWords([FromQuery] int count = 10)
    {
        var words = await _wordService.GetWordsAsync(count);
        
        if (words.Count == 0)
        {
            return NotFound("No words available in the database.");
        }
        
        return Ok(words);
    }
}