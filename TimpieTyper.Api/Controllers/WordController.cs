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

    [HttpGet("{count:int}")]
    public async Task<IActionResult> GetAsync(int count = 10)
    {
        var words = await _wordService.GetAsync(count);
        
        return Ok(words);
    }
}