using MatlabProject.Api.Middlewares;
using MatlabProject.Application.Common.EventBus.Brokers;
using MatlabProject.Application.Common.Settings;
using MatlabProject.Application.Identity.Services;
using MatlabProject.Domain.Common.Serializers;
using MatlabProject.Domain.Constants;
using MatlabProject.Infrastructure.Common.Caching;
using MatlabProject.Infrastructure.Common.EventBus.Brokers;
using MatlabProject.Infrastructure.Common.EventBus.Extensions;
using MatlabProject.Infrastructure.Common.Serializers;
using MatlabProject.Infrastructure.Identity.Services;
using MatlabProject.Persistence.Caching.Brokers;
using MatlabProject.Persistence.DataContexts;
using MatlabProject.Persistence.Repositories.Interfaces;
using MatlabProject.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using MatlabProject.Application.Questions.Services;
using MatlabProject.Infrastructure.Questions.Services;
using MatlabProject.Application.Verification.Services;
using MatlabProject.Infrastructure.Verification.Services;
using MatlabProject.Application.Notifications.Brokers;
using MatlabProject.Application.Notifications.Services;
using MatlabProject.Infrastructure.Notifications.Brokers;
using MatlabProject.Infrastructure.Notifications.Services;
using MassTransit.SqlTransport;
using MatlabProject.Domain.Brokers;
using MatlabProject.Infrastructure.Common.RequestContexts.Brokers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MatlabProject.Api.Data;
using MatlabProject.Api.Configurations;
using MatlabProject.Application.AnswerOptions.Services;
using MatlabProject.Application.Certificates.Services;
using MatlabProject.Application.StudentAnswers.Services;
using MatlabProject.Application.Tests.Services;
using MatlabProject.Infrastructure.AnswerOptions.Services;
using MatlabProject.Infrastructure.Certificates.Services;
using MatlabProject.Infrastructure.StudentAnswers.Services;
using MatlabProject.Infrastructure.Tests.Services;

namespace MatlabProject.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddSerializers(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IJsonSerializationSettingsProvider, JsonSerializationSettingsProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        // register configurations 
        builder.Services.Configure<ValidationSettings>(builder.Configuration.GetSection(nameof(ValidationSettings)));

        // register fluent validation
        builder.Services.AddValidatorsFromAssemblies(Assemblies).AddFluentValidationAutoValidation();

        return builder;
    }

    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

        builder.Services.AddLazyCache();

        builder.Services.AddSingleton<ICacheBroker, LazyMemoryCacheBroker>();

        builder.Services.AddSingleton<AccessTokenValidationMiddleware>();

        return builder;
    }

    private static WebApplicationBuilder AddEventBus(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddMassTransit(configuration =>
            {
                var serviceProvider = configuration.BuildServiceProvider();
                var jsonSerializerSettingsProvider = serviceProvider.GetRequiredService<IJsonSerializationSettingsProvider>();

                configuration.RegisterAllConsumers(Assemblies);
                configuration.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);

                    cfg.UseNewtonsoftJsonSerializer();
                    cfg.UseNewtonsoftJsonDeserializer();

                    cfg.ConfigureNewtonsoftJsonSerializer(settings => jsonSerializerSettingsProvider.ConfigureForEventBus(settings));
                    cfg.ConfigureNewtonsoftJsonDeserializer(settings => jsonSerializerSettingsProvider.ConfigureForEventBus(settings));
                });
            });

        builder.Services.AddSingleton<IEventBusBroker, MassTransitEventBusBroker>();

        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        var dbConnectionString =
            builder.Configuration.GetConnectionString(DataAccessConstants.DbConnectionString) ??
            Environment.GetEnvironmentVariable(DataAccessConstants.DbConnectionString);

        var logger = builder.Services.BuildServiceProvider().GetService<ILogger<Program>>();

        logger?.LogInformation("Environment: {Environment}", builder.Environment.EnvironmentName);
        logger?.LogInformation("Connection String Present: {HasConnection}", !string.IsNullOrEmpty(dbConnectionString));
        logger?.LogDebug("Connection String: {ConnectionString}", dbConnectionString);

        builder.Services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(dbConnectionString); });

        return builder;
    }

    private static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations
        builder.Services.Configure<PasswordValidationSettings>(builder.Configuration.GetSection(nameof(PasswordValidationSettings)));
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        // register repositories
        builder.Services.AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserSettingsRepository, UserSettingsRepository>()
            .AddScoped<IAccessTokenRepository, AccessTokenRepository>();

        // register helper foundation services
        builder.Services.AddTransient<IPasswordHasherService, PasswordHasherService>()
            .AddTransient<IPasswordGeneratorService, PasswordGeneratorService>()
            .AddTransient<IAccessTokenGeneratorService, AccessTokenGeneratorService>();

        // register foundation data access services
        builder.Services.AddScoped<IUserService, UserService>()
            .AddScoped<IUserSettingsService, UserSettingsService>()
            .AddScoped<IAccessTokenService, AccessTokenService>();

        // register other higher services
        builder.Services.AddScoped<IAccountAggregatorService, AccountAggregatorService>()
            .AddScoped<IAuthAggregationService, AuthAggregationService>();

        // register authentication handlers
        var jwtSettings = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>() ??
                          throw new InvalidOperationException("JwtSettings is not configured.");

        // add authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                options =>
                {
                    options.RequireHttpsMetadata = false;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = jwtSettings.ValidateIssuer,
                        ValidIssuer = jwtSettings.ValidIssuer,
                        ValidAudience = jwtSettings.ValidAudience,
                        ValidateAudience = jwtSettings.ValidateAudience,
                        ValidateLifetime = jwtSettings.ValidateLifetime,
                        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    };
                }
            );

        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations 
        builder.Services.Configure<TemplateRenderingSettings>(builder.Configuration.GetSection(nameof(TemplateRenderingSettings)))
            .Configure<SmtpEmailSenderSettings>(builder.Configuration.GetSection(nameof(SmtpEmailSenderSettings)))
            //.Configure<TwilioSmsSenderSettings>(builder.Configuration.GetSection(nameof(TwilioSmsSenderSettings)))
            .Configure<NotificationSettings>(builder.Configuration.GetSection(nameof(NotificationSettings)));

        builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>().AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();

        // register brokers
        builder.Services.AddScoped<IEmailSenderBroker, SmtpEmailSenderBroker>().AddScoped<IEmailHistoryRepository, EmailHistoryRepository>();

        // register data access foundation services
        _ = builder.Services.AddScoped<IEmailTemplateService, EmailTemplateService>().AddScoped<IEmailHistoryService, EmailHistoryService>();

        // register helper foundation services
        builder.Services.AddScoped<IEmailSenderService, EmailSenderService>().AddScoped<IEmailRenderingService, EmailRenderingService>();

        return builder;
    }

    private static WebApplicationBuilder AddVerificationInfrastructure(this WebApplicationBuilder builder)
    {
        // register configurations
        builder.Services.Configure<VerificationSettings>(builder.Configuration.GetSection(nameof(VerificationSettings)));

        // register repositories
        builder.Services.AddScoped<IUserInfoVerificationCodeRepository, UserInfoVerificationCodeRepository>();

        // register foundation data access services
        builder.Services.AddScoped<IUserInfoVerificationCodeService, UserInfoVerificationCodeService>();

        // register other higher services
        builder.Services.AddScoped<IVerificationProcessingService, VerificationProcessingService>();

        return builder;
    }

    private static WebApplicationBuilder AddTemplateInfrastructure(this WebApplicationBuilder builder)
    {
        //registering repositories
        builder
            .Services
            .AddScoped<IAnswerOptionRepository, AnswerOptionRepository>()
            .AddScoped<ICertificateRepository, CertificateRepository>()
            .AddScoped<IQuestionRepository, QuestionRepository>()
            .AddScoped<IStudentAnswerRepository, StudentAnswerRepository>()
            .AddScoped<ITestRepository, TestRepository>()
            .AddScoped<ITestResultRepository, TestResultRepository>();

        //registering services
        builder
            .Services
            .AddScoped<IAnswerOptionService, AnswerOptionService>()
            .AddScoped<ICertificateService, CertificateService>()
        .AddScoped<IQuestionService, QuestionService>()
            .AddScoped<IStudentAnswerService, StudentAnswerService>()
            .AddScoped<ITestService, TestService>()
            .AddScoped<ITestResultService, TestResultService>();

        return builder;
    }

    private static WebApplicationBuilder AddMediatR(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddMediatR(conf => { conf.RegisterServicesFromAssemblies(Assemblies.ToArray()); });

        return builder;
    }

    private static WebApplicationBuilder AddReqeuestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();

        builder.Services.AddScoped<IRequestContextProvider, RequestContextProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        policyBuilder
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();
                    }
                );
            }
        );

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<ApiBehaviorOptions>
            (options => { options.SuppressModelStateInvalidFilter = true; });

        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers().AddNewtonsoftJson();

        return builder;
    }

    private static async ValueTask<WebApplication> MigratedataBaseSchemasAsync(this WebApplication app)
    {
        var serviceScopeFactory = app.Services.GetRequiredKeyedService<IServiceScopeFactory>(null);

        await serviceScopeFactory.MigrateAsync<AppDbContext>();

        return app;
    }

    private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        await serviceScope.ServiceProvider.InitializeSeedAsync();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseIdentityInfrustructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}