using Domain.Enums;

namespace Application.Booking.Dtos;

public class BookingDto
{
    public BookingDto()
    {
        this.PlacedAt = DateTime.UtcNow;
    }

    public int Id { get; set; }
    public DateTime PlacedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int RoomId { get; set; }
    public int GuestId { get; set; }
    private Status Status { get; set; }

    public static Domain.Entities.Booking MapToEntity(BookingDto bookingDto)
    {
        return new Domain.Entities.Booking
        {
            Id = bookingDto.Id,
            Start = bookingDto.Start,
            Guest = new Domain.Entities.Guest { Id = bookingDto.GuestId },
            Room = new Domain.Entities.Room { Id = bookingDto.RoomId },
            End = bookingDto.End,
            PlacedAt = bookingDto.PlacedAt,
        };
    }
}