using DiscordBot.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DiscordBot.Api.Controllers;

/// <summary>
///     Used by the bot website to "register" interested users
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
// [Authorize(Policies.IsWebsite)] TODO - Setup authorization
public class InterestController(IRegisteredInterestRepository registeredInterestRepository) : ControllerBase
{
    private readonly IRegisteredInterestRepository _registeredInterestRepository = registeredInterestRepository;

    /// <summary>
    ///     Register a users interest in the discord bot
    /// </summary>
    /// <response code="204">Returned after a successful interest registration</response>
    /// <response code="400">Returned when invalid interest data is provided</response>
    [HttpPost("register")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult RegisterUserInterest()
    {
        // Sanitize input

        // Validate input

        // Save user interest to DB

        return NoContent();
    }
}
