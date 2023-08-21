using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Runtime.CompilerServices;
using Santander.CodingTest.Application.Queries;

namespace Santander.CodingTest.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BestStoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BestStoriesController> _logger;

    public BestStoriesController(IMediator mediator, ILogger<BestStoriesController> logger)
        => (_mediator, _logger) = (mediator, logger);

    [HttpGet("{count}")]
    public async Task<IActionResult> Get(int count)
    {
        var results = await _mediator.Send(new GetBestStoriesQuery(count));
        return results.Any() ? Ok(results) : NoContent();
    }

	[HttpGet("item/{id}")]
	public async Task<IActionResult> GetStory(int id)
	{
		var story = await _mediator.Send(new GetStoryQuery(id));
		return story != null ? Ok(story) : NoContent();
	}
}
