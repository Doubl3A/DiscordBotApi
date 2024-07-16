using DiscordBot.Api.Models.Database;

namespace DiscordBot.Api.Interfaces;

/// <summary>
///     Collection of methods used to administrate the registered interest's in the DB
/// </summary>
public interface IRegisteredInterestRepository
{
    /// <summary>
    ///     Register a new user interest
    /// </summary>
    void RegisterNewInterest();

    /// <summary>
    ///     Get all registered interests
    /// </summary>
    /// <returns>A <see cref="IEnumerable{T}" /> with all registered interests</returns>
    Task<IEnumerable<RegisteredInterest>> GetRegisteredInterests();
}
