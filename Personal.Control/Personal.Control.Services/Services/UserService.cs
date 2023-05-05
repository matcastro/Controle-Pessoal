using AutoMapper;
using Personal.Control.Repositories.Repositories.Interfaces;
using Personal.Control.Services.Services.Interfaces;
using User = Personal.Control.Services.Models.User;

namespace Personal.Control.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<User> Register(User user)
        {
            var userDb = _mapper.Map<Repositories.Models.User>(user);
            await _userRepository.Save(userDb);
            return user;
        }
    }
}
