using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Guest.DTO;

public class GuestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string IdNumber { get; set; }
    public int IdTypeCode { get; set; }

    public static Domain.Entities.Guest MapToEntity(GuestDTO guestDto)
    {
        return new Domain.Entities.Guest
        {
            Id = guestDto.Id,
            Name = guestDto.Name,
            Surname = guestDto.Surname,
            Email = guestDto.Email,
            DocumentId = new PersonId
            {
                IdNumber = guestDto.IdNumber,
                DocumentType = (DocumentType)guestDto.IdTypeCode
            }
        };
    }

    public static GuestDTO MapToDto(Domain.Entities.Guest guest)
    {
        return new GuestDTO
        {
            Id = guest.Id,
            Email = guest.Email,
            IdNumber = guest.DocumentId.IdNumber,
            IdTypeCode = (int)guest.DocumentId.DocumentType,
            Name = guest.Name,
            Surname = guest.Surname
        };
    }
}