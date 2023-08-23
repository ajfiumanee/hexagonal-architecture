using Application.Payment;
using Application.Payment.Ports;

namespace Application;

public class NotImplementedPaymentProvider: IPaymentProcessor
{
    public Task<PaymentResponse> CapturePayment(string paymentIntention)
    {
        var paymentResponse = new PaymentResponse() 
        { 
            Success = false,
            ErrorCode = ErrorCodes.PAYMENT_PROVIDER_NOT_IMPLEMENTED,
            Message = "The selected payment provider is not available at the moment"
        };

        return Task.FromResult(paymentResponse);
    }
}