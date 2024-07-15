using Serilog;

namespace DiscordBot.Api.Extensions;

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
}
