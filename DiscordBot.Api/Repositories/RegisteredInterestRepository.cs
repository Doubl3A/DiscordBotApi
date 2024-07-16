using DiscordBot.Api.DbContexts;
using DiscordBot.Api.Interfaces;
using DiscordBot.Api.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Api.Repositories;

/// <inheritdoc />
public class RegisteredInterestRepository(RegisteredInterestContext registeredInterestContext)
    : IRegisteredInterestRepository
{
    /// <inheritdoc />
    public void RegisterNewInterest()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<IEnumerable<RegisteredInterest>> GetRegisteredInterests()
    {
        // TODO - paginate results to future proof
        return await registeredInterestContext.InterestRegistrations
            .OrderBy(registration => registration.TimeRegistered)
            .ToListAsync();
    }
}
