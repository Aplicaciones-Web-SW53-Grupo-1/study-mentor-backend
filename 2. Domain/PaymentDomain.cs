using _3._Data;

namespace _2._Domain;

public class PaymentDomain: IPaymentDomain
{
    private IPaymentData _paymentData;

    public PaymentDomain(IPaymentData paymentData)
    {
        _paymentData = paymentData;
    }
    public bool Create(string cardNumber, string expirationDate, int cvv, string owner)
    {
        return _paymentData.Create(cardNumber, expirationDate, cvv, owner);
    }
}