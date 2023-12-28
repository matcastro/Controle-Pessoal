using AutoFixture;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Personal.Control.Controllers;
using Personal.Control.Mappings;
using Personal.Control.Models.Requests;
using Personal.Control.Models.Responses;
using Personal.Control.Services.Models;
using Personal.Control.Services.Services.Interfaces;
using Personal.Control.Utils.Helpers;
using System.Net;
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
        private readonly IMapper _mapper;

        public UsersControllerTests()
        {
            _fixture = new Fixture();
            _userServiceMock = new Mock<IUserService>();
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<UserMapperConfig>());
            _mapper = new Mapper(mapperConfiguration);
            _usersController = new UsersController(_mapper, _userServiceMock.Object);

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
            var user = _fixture.Create<User>();
            _userServiceMock.Setup(us => us.RegisterAsync(It.IsAny<User>())).ReturnsAsync(() => user);

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
        public async Task Register_WhenRequestValid_ShouldCallServiceWithMappedPassword()
        {
            var request = _fixture
               .Build<UserRequest>()
               .With(user => user.Email, ValidEmail)
               .With(user => user.Password, ValidPassword)
               .Create();
            var response = await _usersController.Register(request);

            _userServiceMock.Verify(us => us.RegisterAsync(
                It.Is<User>(u => u.Password != request.Password && u.PasswordSalt.Length == 64)), Times.Once);
        }

        [Fact]
        public async Task Get_WhenIdNotFilled_ShouldReturnBadRequest()
        {
            string id = string.Empty;
            var response = await _usersController.Get(id);
            Assert.IsType<BadRequestObjectResult>(response);
            Assert.Equal((int)HttpStatusCode.BadRequest, ((BadRequestObjectResult)response).StatusCode);
        }

        [Fact]
        public async Task Get_WhenExistentId_ShouldReturnUserData()
        {
            var id = _fixture.Create<string>();

            var user = _fixture.Build<User>()
               .With(user => user.Id, id)
               .Create();
            _userServiceMock.Setup(us => us.GetAsync(id)).ReturnsAsync(() => user);

            var response = await _usersController.Get(id);

            Assert.IsType<OkObjectResult>(response);
            Assert.IsType<UserResponse>((response as OkObjectResult)?.Value);

            var responseBody = (response as OkObjectResult)?.Value as UserResponse;
            Assert.Equal(id, responseBody?.Id);
            Assert.Equal(user.Email, responseBody?.Email);
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
        public async Task Update_WhenValidRequest_ShouldUpdateUserIgnoringPassword()
        {
            var id = _fixture.Create<string>();
            var request = _fixture
               .Build<UserRequest>()
               .With(user => user.Email, ValidEmail)
               .With(user => user.Password, ValidPassword)
               .Create();
            await _usersController.Update(id, request);
            _userServiceMock.Verify(us => us.UpdateAsync(
                It.Is<User>(u => u.Email == request.Email && string.IsNullOrWhiteSpace(u.Password))), Times.Once);
        }

        [Fact]
        public void Update_WhenInvalidEmail_ShouldThrowArgumentException()
        {
            var id = _fixture.Create<string>();
            var request = _fixture.Create<UserRequest>();
            Assert.ThrowsAsync<ArgumentException>(() => _usersController.Update(id, request));
        }
    }
}
