using Application;
using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class GuestController : ControllerBase
{
    public class GuestsController : ControllerBase
    {
        private readonly ILogger<GuestsController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestsController(
            ILogger<GuestsController> logger,
            IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDTO>> Post(GuestDTO guest)
        {
            var request = new CreateGuestRequest
            {
                Data = guest
            };

            var res = await _guestManager.CreateGuest(request);

            if (res.Success) return Created("", res.Data);

            if (res.ErrorCode == ErrorCodes.NOT_FOUND)
            {
                return NotFound(res);
            }

            _logger.LogError("Response with unknown ErrorCode Returned", res);
            return BadRequest(500);
        }
    }
}