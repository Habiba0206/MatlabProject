using MatlabProject.Api.Configurations;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        await builder.ConfigureAsync();

        var app = builder.Build();

        await app.ConfigureAsync();
        await app.RunAsync();
    }
}