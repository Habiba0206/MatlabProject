using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.AnswerOptions.Models;

namespace MatlabProject.Application.AnswerOptions.Queries;

public class AnswerOptionGetByIdQuery : IQuery<AnswerOptionDto?>
{
    public Guid AnswerOptionId { get; set; }
}
