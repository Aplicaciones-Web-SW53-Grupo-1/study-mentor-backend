using _1._API.Request;
using _1._API.Response;
using _3._Data.Model;
using AutoMapper;

namespace _1._API.Mapper;

public class ModelToAPI: Profile
{
    public ModelToAPI()
    {
        CreateMap<Payment, PaymentRequest>();
        CreateMap<Payment, PaymentResponse>();
        CreateMap<Review, ReviewResponse>();
        CreateMap<Review, ReviewRequest>();
    }
}