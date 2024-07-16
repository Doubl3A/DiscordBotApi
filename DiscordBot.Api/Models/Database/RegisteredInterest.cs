using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscordBot.Api.Models.Database;

/// <summary>
///     Saved DB model of users who registered as interested on the website
/// </summary>
public class RegisteredInterest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    ///     The time and date of when the user registered their interest
    /// </summary>
    [Required]
    public DateTime TimeRegistered { get; set; }
}
