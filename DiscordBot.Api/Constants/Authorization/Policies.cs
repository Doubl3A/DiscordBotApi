namespace DiscordBot.Api.Constants.Authorization;

/// <summary>
///     Different authentication policies used around the API
/// </summary>
public static class Policies
{
    /// <summary>
    ///     Used by the discord bot website
    /// </summary>
    public const string IsWebsite = "MustBeWebsite";
}
