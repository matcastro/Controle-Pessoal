using AutoFixture;
using Personal.Control.Services.Models;
using Xunit;

namespace Personal.Control.Services.Tests.Models
{
    public class UserTests
    {
        private readonly Fixture _fixture;

        public UserTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void SetPassword_WhenCalled_ShouldSetEncryptedPassword()
        {
            var password = _fixture.Create<string>();
            var user = new User { Password = password };

            Assert.NotNull(user?.Password);
            Assert.NotEmpty(user.Password);
            Assert.NotEqual(password, user.Password);
        }
    }
}
