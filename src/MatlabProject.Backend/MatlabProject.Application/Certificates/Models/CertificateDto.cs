namespace MatlabProject.Application.Certificates.Models;

public class CertificateDto
{
    public Guid? Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public DateTimeOffset IssuedAt { get; set; }
    public string FilePath { get; set; } = default!;
}
