using Application.Guest.DTO;
using Application.Guest.Ports;
using Application.Guest.Requests;
using Application.Guest.Responses;
using Domain.Ports;

namespace Application;

public class GuestManager : IGuestManager
{
    private IGuestRepository _guestRepository;

    public GuestManager(IGuestRepository guestManager)
    {
        _guestRepository = _guestRepository;
    }

    public async Task<GuestResponse> CreateGuest(CreateGuestRequest request)
    {
        try
        {
            var guest = GuestDTO.MapToEntity(request.Data);
            request.Data.Id = await _guestRepository.Create(guest);
            return new GuestResponse
            {
                Data = request.Data,
                Success = true
            };
        }
        catch (Exception)
        {
            return new GuestResponse
            {
                Success = false,
                ErrorCode = ErrorCodes.COULDNOT_STORE_DATE,
                Message = "There was an error when saving to DB"
            };
        }
    }
}