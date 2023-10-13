using Personal.Control.Models.Requests;
using Xunit;

namespace Personal.Control.Tests.Models.Requests
{
    public class UserRequestTests
    {
        [Theory]
        [InlineData(" aa@a.co", "aa@a.co")]
        [InlineData("aa@a.co ", "aa@a.co")]
        [InlineData(" aa@a.co ", "aa@a.co")]
        [InlineData("  aa@a.co\n", "aa@a.co")]
        [InlineData(" \taa@a.co ", "aa@a.co")]
        public void SetEmail_WhenEmailHasStartingOrEndingWhitespaces_ShouldRemoveIt(string input, string expected)
        {
            var userRequest = new UserRequest() { Email = input };
            Assert.Equivalent(expected, userRequest.Email);
        }
    }
}
