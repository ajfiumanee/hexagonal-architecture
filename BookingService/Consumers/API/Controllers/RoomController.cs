using Application;
using Application.Room.Dtos;
using Application.Room.Ports;
using Application.Room.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly ILogger<GuestController.GuestsController> _logger;
    private readonly IRoomManager _roomManager;

    public RoomController(
        ILogger<GuestController.GuestsController> logger,
        IRoomManager roomManager)
    {
        _logger = logger;
        _roomManager = roomManager;
    }

    [HttpPost]
    public async Task<ActionResult<RoomDto>> Post(RoomDto room)
    {
        var request = new CreateRoomRequest
        {
            Data = room,
            // get this from logged user i.e: user.Roles
            UserName = "fulano de tal"
        };

        var res = await _roomManager.CreateRoom(request);

        if (res.Success) return Created("", res.Data);

        else if (res.ErrorCode == ErrorCodes.ROOM_MISSING_REQUIRED_INFORMATION)
        {
            return BadRequest(res);
        }
        else if (res.ErrorCode == ErrorCodes.ROOM_COULD_NOT_STORE_DATA)
        {
            return BadRequest(res);
        }

        _logger.LogError("Response with unknown ErrorCode Returned", res);
        return BadRequest(500);
    }

    [HttpGet]
    public async Task<ActionResult<RoomDto>> Get(int roomId)
    {
        var res = await _roomManager.GetRoom(roomId);

        if (res.Success) return Ok(res.Data);

        return NotFound(res);
    }
}