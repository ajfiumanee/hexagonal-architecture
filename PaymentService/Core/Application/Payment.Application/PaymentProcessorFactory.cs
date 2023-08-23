using Application.MercadoPago;
using Application.Payment.Enums;
using Application.Payment.Ports;

namespace Application;

public class PaymentProcessorFactory : IPaymentProcessorFactory
{
    public IPaymentProcessor GetPaymentProcessor(SupportedPaymentProviders selectedPaymentProvider)
    {
        switch (selectedPaymentProvider)
        {
            case SupportedPaymentProviders.MercadoPago:
                return new MercadoPagoAdapter();

            default: return new NotImplementedPaymentProvider();
        }
    }
}