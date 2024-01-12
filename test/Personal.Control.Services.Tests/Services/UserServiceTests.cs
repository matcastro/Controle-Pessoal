using AutoFixture;
using AutoMapper;
using Moq;
using Personal.Control.Mappings;
using Personal.Control.Repositories.Repositories.Interfaces;
using Personal.Control.Services.Models;
using Personal.Control.Services.Services;
using Personal.Control.Services.Services.Interfaces;
using Personal.Control.Utils.Exceptions;
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
        public async Task RegisterAsync_WhenCalled_ShouldSavePasswordWithSaltAndPassword()
        {
            var user = _fixture.Create<User>();
            await _userService.RegisterAsync(user);

            _userRepository.Verify(ur => ur.SaveAsync(It.Is<Repositories.Models.User>(
                u => u.Password.Contains(Convert.ToBase64String(user.PasswordSalt)) &&
                u.Password.Contains(user.Password))), Times.Once);
        }

        [Fact]
        public async Task GetAsync_WhenExistingUser_ShouldReturnUserMappedFromDatabase()
        {
            var userDb = _fixture.Create<Repositories.Models.User>();
            _userRepository.Setup(ur => ur.GetAsync(userDb.Id)).ReturnsAsync(() => userDb);
            var user = await _userService.GetAsync(userDb.Id);
            Assert.Equal(user.Id, userDb.Id);
            Assert.Equal(user.Email, userDb.Email);
            Assert.Equal(user.Password, userDb.Password);
        }

        [Fact]
        public async Task GetAsync_WhenCalled_ShouldUpdateOnDatabase()
        {
            var user = _fixture.Create<User>();
            await _userService.UpdateAsync(user);
            _userRepository.Verify(ur => ur.UpdateAsync(It.IsAny<Repositories.Models.User>()), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_WhenCalled_ShouldDeleteOnDatabase()
        {
            var id = _fixture.Create<string>();
            await _userService.DeleteAsync(id);
            _userRepository.Verify(ur => ur.DeleteAsync(id), Times.Once);
        }
    }
}
