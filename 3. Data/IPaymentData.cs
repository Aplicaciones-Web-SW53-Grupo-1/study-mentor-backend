using _3._Data.Model;

namespace _3._Data;

public interface IPaymentData
{
    public Payment GetById(int id);
    public List<Payment> GetAll();
    public bool Create(string cardNumber, string expirationDate, int cvv, string owner);
}