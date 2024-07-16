using DiscordBot.Api.DbContexts;
using DiscordBot.Api.Interfaces;
using DiscordBot.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DiscordBot.Api.Extensions.Startup;

/// <summary>
///     A collection of extension methods for <see cref="WebApplicationBuilder" />
/// </summary>
public static class WebApplicationBuilderExtensions
{
    #region Logging

    /// <summary>
    ///     Add preconfigured serilog to the applicaiton
    /// </summary>
    public static WebApplicationBuilder AddConfiguredSerilog(this WebApplicationBuilder builder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (environment == Environments.Development)
        {
            builder.Host.UseSerilog(
                (context, loggerConfiguration) => loggerConfiguration
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
            );
        }

        // TODO - Add production logging ex. Application insights
        return builder;
    }

    #endregion

    #region Database

    /// <summary>
    ///     Configure the application with the relevant DB context's
    /// </summary>
    public static WebApplicationBuilder AddConfiguredDb(this WebApplicationBuilder builder)
    {
        // Shared DB connection string
        var dbConnectionString = builder.Configuration["ConnectionStrings:WebApiDatabase"];

        builder.Services.AddDbContext<RegisteredInterestContext>(
            dbContextOptions => dbContextOptions.UseNpgsql(dbConnectionString)
        );

        return builder;
    }

    #endregion

    #region Custom services

    /// <summary>
    ///     Add custom services to the application
    /// </summary>
    public static WebApplicationBuilder AddCustomServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRegisteredInterestRepository, RegisteredInterestRepository>();

        return builder;
    }

    #endregion
}
