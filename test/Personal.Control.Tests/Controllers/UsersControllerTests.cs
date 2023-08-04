using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Personal.Control.Controllers;
using Personal.Control.Models.Requests;
using Personal.Control.Models.Responses;
using Personal.Control.Services.Models;
using Personal.Control.Services.Services.Interfaces;
using Personal.Control.Utils.Helpers;
using Xunit;

namespace Personal.Control.Tests.Controllers
{
    public class UsersControllerTests
    {
        private const string ValidEmail = "aa@a.co";
        private const string ValidPassword = "Aa1!Aa";
        private readonly Fixture _fixture;
        private readonly UsersController _usersController;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IMapper> _mapper;

        public UsersControllerTests()
        {
            _fixture = new Fixture();
            _userServiceMock = new Mock<IUserService>();
            _mapper = new Mock<IMapper>();
            _usersController = new UsersController(_mapper.Object, _userServiceMock.Object);

            ConfigurationHelper.Initialize(new Utils.Configs.Config
            {
                Validation = new Utils.Configs.ValidationConfig
                {
                    PasswordMinimumLength = 6,
                    PasswordMaximumLength = 8
                }
            });
        }

        [Fact]
        public async Task Register_WhenRequestWithInvalidEmail_ShouldThrowArgumentException()
        {
            var request = _fixture.Create<UserRequest>();
            await Assert.ThrowsAsync<ArgumentException>(() => _usersController.Register(request));
        }

        [Theory]
        [InlineData("xx")]
        [InlineData("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")]
        public async Task Register_WhenRequestWithPasswordLengthOutOfBounds_ShouldThrowArgumentOutOfRangeException(string password)
        {
            var request = _fixture
                .Build<UserRequest>()
                .With(user => user.Email, ValidEmail)
                .With(user => user.Password, password)
                .Create();
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => _usersController.Register(request));
        }

        [Theory]
        [InlineData("abcdef")]
        [InlineData("Ab11aa")]
        [InlineData("Ab!#aa")]
        [InlineData("bffWF315")]
        public async Task Register_WhenRequestWithPasswordInvalid_ShouldThrowArgumentException(string password)
        {
            var request = _fixture
                .Build<UserRequest>()
                .With(user => user.Email, ValidEmail)
                .With(user => user.Password, password)
                .Create();
            await Assert.ThrowsAsync<ArgumentException>(() => _usersController.Register(request));
        }

        [Fact]
        public async Task Register_WhenRequestValid_ShouldReturnOkWithGeneratedId()
        {
            var request = _fixture
               .Build<UserRequest>()
               .With(user => user.Email, ValidEmail)
               .With(user => user.Password, ValidPassword)
               .Create();
            var user = new User();
            var userResponse = new UserResponse { Id = user.Id };
            _userServiceMock.Setup(us => us.RegisterAsync(It.IsAny<User>())).ReturnsAsync(() => user);
            _mapper.Setup(m => m.Map<UserResponse>(It.IsAny<User>())).Returns(() => userResponse);

            var response = await _usersController.Register(request);

            Assert.IsType<OkObjectResult>(response);

            var responseResult = response as OkObjectResult;
            Assert.Equal(200, responseResult?.StatusCode);
            Assert.IsType<UserResponse>(responseResult?.Value);

            var userResponseResult = responseResult.Value as UserResponse;
            Assert.NotNull(userResponseResult);
            Assert.False(string.IsNullOrWhiteSpace(userResponseResult.Id));
        }

        [Fact]
        public void Get_WhenCalled_ShouldThrowNotImplementedException()
        {
            var id = _fixture.Create<string>();
            Assert.Throws<NotImplementedException>(() => _usersController.Get(id));
        }

        [Fact]
        public void ResetPassword_WhenCalled_ShouldThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(() => _usersController.ResetPassword());
        }

        [Fact]
        public void Delete_WhenCalled_ShouldThrowNotImplementedException()
        {
            var id = _fixture.Create<string>();
            Assert.Throws<NotImplementedException>(() => _usersController.Delete(id));
        }

        [Fact]
        public void GetPermissions_WhenCalled_ShouldThrowNotImplementedException()
        {
            var id = _fixture.Create<string>();
            Assert.Throws<NotImplementedException>(() => _usersController.GetPermissions(id));
        }

        [Fact]
        public void Update_WhenCalled_ShouldThrowNotImplementedException()
        {
            var id = _fixture.Create<string>();
            Assert.Throws<NotImplementedException>(() => _usersController.Update(id));
        }
    }
}
