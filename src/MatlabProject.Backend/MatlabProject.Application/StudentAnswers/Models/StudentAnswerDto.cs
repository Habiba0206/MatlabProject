﻿namespace MatlabProject.Application.StudentAnswers.Models;

public class StudentAnswerDto
{
    public Guid? Id { get; set; }
    public Guid TestResultId { get; set; }
    public Guid QuestionId { get; set; }
    public string SelectedAnswer { get; set; } = default!;
    public bool IsCorrect { get; set; }
}
