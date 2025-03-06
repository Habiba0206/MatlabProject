using MatlabProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Persistence.DataContexts;
public class AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<UserSettings> UserSettings => Set<UserSettings>();
    public DbSet<UserInfoVerificationCode> UserInfoVerificationCodes => Set<UserInfoVerificationCode>();
    public DbSet<AccessToken> AccessTokens => Set<AccessToken>();
    public DbSet<Test> Tests => Set<Test>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();
    public DbSet<TestResult> TestResults => Set<TestResult>();
    public DbSet<Certificate> Certificates => Set<Certificate>();
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();
    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
} 
