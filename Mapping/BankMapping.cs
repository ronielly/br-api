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
            CreateMap<BankResponse, BankModel>();
            CreateMap<BankModel, BankResponse>();
        }
    }
}