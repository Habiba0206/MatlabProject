using MatlabProject.Application.Tests.Commands;
using MatlabProject.Application.Tests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatlabProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] TestGetQuery testGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(testGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{testId:guid}")]
    public async ValueTask<IActionResult> GetTestById([FromRoute] Guid testId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new TestGetByIdQuery { TestId = testId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateTest([FromBody] TestCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateTest([FromBody] TestUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{testId:guid}")]
    public async ValueTask<IActionResult> DeleteTestById([FromRoute] Guid testId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new TestDeleteByIdCommand { TestId = testId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
