using AutoMapper;
using ReactApp1.Server.DTO;
using ReactApp1.Server.Models;

namespace ReactApp1.Server.Util
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CreateTime, opt => opt.MapFrom(src => src.CreateTime));


        }
    }
}