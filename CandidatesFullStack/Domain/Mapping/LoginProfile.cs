using AutoMapper;
using BeeEngineering.Domain.Dto;
using BeeEngineering.Domain.Models;

namespace BeeEngineering.Domain.Mapping
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<Login, LoginDto>().ReverseMap();
        }
    }
}