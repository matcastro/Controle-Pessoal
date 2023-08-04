using Personal.Control.Controllers;
using Xunit;

namespace Personal.Control.Tests.Controllers
{
    public class AuthControllerTests
    {
        private readonly AuthController _authController;

        public AuthControllerTests()
        {
            _authController = new AuthController();
        }

        [Fact]
        public void Login_WhenCalled_ShouldThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(_authController.Login);
        }

        [Fact]
        public void RefreshToken_WhenCalled_ShouldThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(_authController.RefreshToken);
        }

        [Fact]
        public void RevokeToken_WhenCalled_ShouldThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(_authController.RevokeToken);
        }

        [Fact]
        public void Status_WhenCalled_ShouldThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(_authController.Status);
        }

        [Fact]
        public void Logout_WhenCalled_ShouldThrowNotImplementedException()
        {
            Assert.Throws<NotImplementedException>(_authController.Logout);
        }
    }
}
