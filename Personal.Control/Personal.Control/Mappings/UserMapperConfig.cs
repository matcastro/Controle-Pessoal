using AutoMapper;
using Personal.Control.Models.Requests;
using Personal.Control.Models.Responses;

namespace Personal.Control.Mappings
{
    public class UserMapperConfig : Profile
    {
        public UserMapperConfig() 
        {
            CreateMap<UserRequest, Services.Models.User>();
            CreateMap<Services.Models.User, Repositories.Models.User>();
            CreateMap<Services.Models.User, UserResponse>();
        }
    }
}
