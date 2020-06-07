using AutoMapper;
using PaymentDemo.Dtos;
using PaymentDemo.Entities;
using PaymentDemo.Models;

namespace PaymentDemo.Helpers.MapperProfiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentDto, Payment>()
                .ForMember(dest => dest.IdState, 
                    opts => opts.MapFrom(src => PaymentStatus.None));
        }
    }
}
