using AutoMapper;
using Personal.Control.Repositories.Repositories.Interfaces;
using Personal.Control.Services.Services.Interfaces;
using Personal.Control.Utils.Exceptions;
using Personal.Control.Utils.Messages;
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

        public async Task<User> GetAsync(string id)
        {
            var userDb = await _userRepository.GetAsync(id);
            var serviceUser = _mapper.Map<User>(userDb);

            return serviceUser;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var userDb = _mapper.Map<Repositories.Models.User>(user);
            await _userRepository.SaveAsync(userDb);
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            var userDb = _mapper.Map<Repositories.Models.User>(user);
            var updatedUserDb = await _userRepository.UpdateAsync(userDb);

            var serviceUser = _mapper.Map<User>(updatedUserDb);
            return serviceUser;
        }
    }
}
