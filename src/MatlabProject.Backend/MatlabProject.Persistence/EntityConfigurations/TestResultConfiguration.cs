using MatlabProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatlabProject.Persistence.EntityConfigurations;

public class TestResultConfiguration : IEntityTypeConfiguration<TestResult>
{
    public void Configure(EntityTypeBuilder<TestResult> builder)
    {
        builder.Property(tr => tr.StartTime)
            .IsRequired();

        builder.Property(tr => tr.EndTime)
            .IsRequired();

        builder.Property(tr => tr.ScorePercentage)
            .IsRequired();

        builder.Property(tr => tr.IsPassed)
            .HasDefaultValue(false);

        builder.HasOne(tr => tr.User)
            .WithMany(u => u.TestResults)
            .HasForeignKey(tr => tr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(tr => tr.Test)
            .WithMany()
            .HasForeignKey(tr => tr.TestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
