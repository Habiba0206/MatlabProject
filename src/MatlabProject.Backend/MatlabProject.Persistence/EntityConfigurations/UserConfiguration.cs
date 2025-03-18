using MatlabProject.Domain.Entities;
using MatlabProject.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatlabProject.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(user => user.FirstName)
            .HasMaxLength(64)
            .IsRequired();
        builder
            .Property(user => user.LastName)
            .HasMaxLength(64)
            .IsRequired();
        builder
            .Property(user => user.EmailAddress)
            .HasMaxLength(128)
            .IsRequired();
        builder
            .Property(user => user.PasswordHash)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .Property(user => user.Role)
            .HasConversion<string>()
            .HasDefaultValue(Role.Student)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .HasIndex(user => user.EmailAddress)
            .IsUnique();

        builder.HasMany(u => u.Tests)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.TestResults)
            .WithOne(tr => tr.User)
            .HasForeignKey(tr => tr.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Certificates)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
