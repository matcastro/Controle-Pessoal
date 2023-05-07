using AutoMapper;
using Personal.Control.Models.Requests;
using Personal.Control.Models.Responses;
using System.Security.Cryptography;

namespace Personal.Control.Mappings
{
    public class UserMapperConfig : Profile
    {
        public UserMapperConfig() 
        {
            CreateMap<UserRequest, Services.Models.User>()
                .ForMember(dest => dest.PasswordSalt, opt => opt.MapFrom(_ => RandomNumberGenerator.GetBytes(64)));
            CreateMap<Services.Models.User, Repositories.Models.User>();
            CreateMap<Services.Models.User, UserResponse>();
        }
    }
}
