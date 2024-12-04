using AutoMapper;
using BrApi.Dtos;
using BrApi.Models;

namespace BrApi.Mapping
{
    public class BankMapping : Profile
    {
        public BankMapping()
        {
            CreateMap(typeof(Response<>), typeof(Response<>));
            CreateMap<BankDto, BankModel>();
            CreateMap<BankModel, BankDto>();
        }
    }
}