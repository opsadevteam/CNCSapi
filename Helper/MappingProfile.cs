using CNCSproject.Models;
using AutoMapper;
using CNCSproject.Dto;
using CNCSapi.Dto;


namespace CNCSproject.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Transactions, TransactionDto>();
            CreateMap<TransactionDto, Transactions>();
            CreateMap<UserAccount, UserAccountDto>();
        }
    }
}
