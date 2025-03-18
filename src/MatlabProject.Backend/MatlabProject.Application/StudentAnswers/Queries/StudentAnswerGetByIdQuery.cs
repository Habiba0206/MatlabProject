using MatlabProject.Domain.Common.Queries;
using MatlabProject.Application.StudentAnswers.Models;

namespace MatlabProject.Application.StudentAnswers.Queries;

public class StudentAnswerGetByIdQuery : IQuery<StudentAnswerDto?>
{
    public Guid StudentAnswerId { get; set; }
}
