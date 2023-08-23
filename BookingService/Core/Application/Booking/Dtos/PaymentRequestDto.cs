using Application.Payment.Enums;

namespace Application.Booking.Dtos;

public class PaymentRequestDto
{
    public int BookingId { get; set; }
    public string PaymentIntention { get; set; }
    public SupportedPaymentProviders SelectedPaymentProvider { get; set; }
    public SupportedPaymentMethods SelectedPaymentMethod { get; set; }
}