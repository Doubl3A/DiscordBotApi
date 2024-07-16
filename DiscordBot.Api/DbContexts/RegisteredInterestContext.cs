using DiscordBot.Api.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace DiscordBot.Api.DbContexts;

/// <summary>
///     DB context for accessing the registered interests
/// </summary>
public class RegisteredInterestContext(DbContextOptions<RegisteredInterestContext> options) : DbContext(options)
{
    public DbSet<RegisteredInterest> InterestRegistrations { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisteredInterest>()
            .HasData(
                new RegisteredInterest
                {
                    Id = 1,
                    TimeRegistered = DateTime.UtcNow,
                }
            );
    }
}
