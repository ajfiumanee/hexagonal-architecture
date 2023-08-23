using Application.Payment.Dtos;

namespace Application.Payment;

public class PaymentResponse: Response
{
    public PaymentStateDto Data { get; set; }
}