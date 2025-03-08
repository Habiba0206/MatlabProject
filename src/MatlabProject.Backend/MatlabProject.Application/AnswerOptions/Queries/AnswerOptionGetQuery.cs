using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.AnswerOptions.Models;

namespace MatlabProject.Application.AnswerOptions.Queries;

public class AnswerOptionGetQuery : IQuery<ICollection<AnswerOptionDto>>
{
    public AnswerOptionFilter AnswerOptionFilter { get; set; }
}
