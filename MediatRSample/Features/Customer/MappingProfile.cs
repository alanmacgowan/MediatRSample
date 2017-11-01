
namespace MediatRSample.Features.Customer
{
    using AutoMapper;
    using MediatRSample.Domain;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, Index.Model>();
            CreateMap<Create.Command, Customer>(MemberList.Source);
            CreateMap<Customer, Edit.Command>().ReverseMap();
            CreateMap<Customer, Details.Model>();
        }

    }
}
