using _3._Data.Context;
using _3._Data.Model;

namespace _3._Data;

public class PaymentMySqlData: IPaymentData
{
    private StudyMentorDB _studyMentorDb;

    public PaymentMySqlData(StudyMentorDB studyMentorDb)
    {
        _studyMentorDb = studyMentorDb;
    }
    public Payment GetById(int id)
    {
        return _studyMentorDb.Payments.Where(t => t.Id == id).First();
    }

    public List<Payment> GetAll()
    {
        return _studyMentorDb.Payments.ToList();
    }

    public bool Create(string cardNumber, string expirationDate, int cvv, string owner)
    {
        throw new NotImplementedException();
    }
}