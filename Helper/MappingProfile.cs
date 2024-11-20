using CNCSproject.Models;
using AutoMapper;
using CNCSproject.Dto;


namespace CNCSproject.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Transactions, TransactionDto>();
            CreateMap<TransactionDto, Transactions>();


        }
    }
}
