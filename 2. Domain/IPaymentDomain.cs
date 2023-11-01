namespace _2._Domain;

public interface IPaymentDomain
{
    public bool Create(string cardNumber, string expirationDate, int cvv, string owner);
}