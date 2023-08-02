using AutoFixture;
using AutoMapper;
using Moq;
using Personal.Control.Mappings;
using Personal.Control.Repositories.Repositories.Interfaces;
using Personal.Control.Services.Models;
using Personal.Control.Services.Services;
using Personal.Control.Services.Services.Interfaces;
using Xunit;

namespace Personal.Control.Services.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Fixture _fixture;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly Mock<IUserRepository> _userRepository;

        public UserServiceTests()
        {
            _fixture = new Fixture();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<UserMapperConfig>());
            _mapper = new Mapper(mapperConfiguration);
            _userRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mapper, _userRepository.Object);
        }

        [Fact]
        public async Task Register_WhenCalled_ShouldSavePasswordWithSaltAndPassword()
        {
            var user = _fixture.Create<User>();
            await _userService.Register(user);

            _userRepository.Verify(ur => ur.Save(It.Is<Repositories.Models.User>(
                u => u.Password.Contains(Convert.ToBase64String(user.PasswordSalt)) &&
                u.Password.Contains(user.Password))), Times.Once);
        }
    }
}
