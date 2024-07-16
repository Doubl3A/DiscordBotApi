namespace DiscordBot.Api.Extensions.Startup;

/// <summary>
///     A collection of custom extension methods for <see cref="WebApplication" />
/// </summary>
public static class WebApplicationExtensions
{
    /// <summary>
    ///     Add development specific customization to the application
    /// </summary>
    public static WebApplication UseDevelopSpecificCustomization(this WebApplication app)
    {
        // Only add if in the development environment
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(
                setupAction =>
                {
                    var descriptions = app.DescribeApiVersions();
                    foreach (var description in descriptions)
                    {
                        setupAction.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant()
                        );
                    }
                }
            );
        }

        return app;
    }
}
