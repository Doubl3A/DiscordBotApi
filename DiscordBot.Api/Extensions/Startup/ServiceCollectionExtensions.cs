using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace DiscordBot.Api.Extensions.Startup;

/// <summary>
///     A collection of setup extensions on <see cref="IServiceCollection" /> used in API configuration
/// </summary>
public static class ServiceCollectionExtensions
{
    #region API versioning

    /// <summary>
    ///     Load the generated swagger documentation from the .xml file at root
    /// </summary>
    /// <remarks>
    ///     This should be done after adding API versioning to the <see cref="IServiceCollection" />
    /// </remarks>
    public static IServiceCollection LoadSwaggerDocumentation(this IServiceCollection services)
    {
        // TODO - Remove builder service provider: https://learn.microsoft.com/en-us/aspnet/core/diagnostics/asp0000?view=aspnetcore-8.0
        var apiVersionDescriptionProvider = services.BuildServiceProvider()
            .GetRequiredService<IApiVersionDescriptionProvider>();

        services.AddSwaggerGen(
            setupAction =>
            {
                // Iterate through all
                foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                {
                    setupAction.SwaggerDoc(
                        $"{description.GroupName}",
                        new OpenApiInfo
                        {
                            Title = "Discord API",
                            Version = description.ApiVersion.ToString(),
                            Description =
                                "API used by the Discord bot and website to track and fetch user interactions.",
                        }
                    );
                }

                // Create the full xml documentation path
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                // Add generated XML documentation
                setupAction.IncludeXmlComments(xmlCommentsFullPath);

                // Add API security information
                // TODO - Still needed here?
                setupAction.AddSecurityDefinition(
                    "DiscordApiBearerAuth",
                    new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = "Bearer",
                        Description = "Input a valid token to access this API",
                    }
                );

                setupAction.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "CityInfoApiBearerAuth",
                                },
                            },
                            new List<string>()
                        },
                    }
                );
            }
        );

        return services;
    }

    /// <summary>
    ///     Add and configure API versioning
    /// </summary>
    public static IServiceCollection AddCustomApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(
                setupAction =>
                {
                    setupAction.ReportApiVersions = true;
                    setupAction.AssumeDefaultVersionWhenUnspecified = true;
                    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
                }
            )
            .AddMvc()
            .AddApiExplorer(setupAction => setupAction.SubstituteApiVersionInUrl = true);

        return services;
    }

    #endregion
}
