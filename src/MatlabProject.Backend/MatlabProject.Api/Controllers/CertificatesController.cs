using MatlabProject.Application.Certificates.Commands;
using MatlabProject.Application.Certificates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MatlabProject.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificatesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] CertificateGetQuery certificateGetQuery, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(certificateGetQuery, cancellationToken);

        return result.Any() ? Ok(result) : NoContent();
    }

    [HttpGet("{certificateId:guid}")]
    public async ValueTask<IActionResult> GetCertificateById([FromRoute] Guid certificateId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CertificateGetByIdQuery { CertificateId = certificateId }, cancellationToken);

        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> CreateCertificate([FromBody] CertificateCreateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return result is not null ? Ok(result) : BadRequest();
    }

    [HttpPut]
    public async ValueTask<IActionResult> UpdateCertificate([FromBody] CertificateUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{answerId:guid}")]
    public async ValueTask<IActionResult> DeleteCertificateById([FromRoute] Guid ertificateId, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(new CertificateDeleteByIdCommand { CertificateId = ertificateId }, cancellationToken);

        return result ? Ok() : BadRequest();
    }
}
