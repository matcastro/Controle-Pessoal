using Microsoft.AspNetCore.Http;
using Moq;
using Personal.Control.Middlewares;
using Personal.Control.Utils.Exceptions;
using System.Net;
using Xunit;

namespace Personal.Control.Tests.Middlewares
{
    public class ExceptionHandlerMiddlewareTests
    {
        private readonly ExceptionHandlerMiddleware _middleware;
        private readonly Mock<RequestDelegate> _requestDelegate;

        public ExceptionHandlerMiddlewareTests()
        {
            _requestDelegate = new Mock<RequestDelegate>();
            _middleware = new ExceptionHandlerMiddleware(_requestDelegate.Object);
        }

        [Fact]
        public async Task Invoke_WhenNextThrowsArgumentException_ShouldSetResponseCodeTo400()
        {
            var ctx = new DefaultHttpContext();
            _requestDelegate.Setup(next => next(ctx)).ThrowsAsync(new ArgumentException());

            await _middleware.Invoke(ctx);

            Assert.Equal((int)HttpStatusCode.BadRequest, ctx.Response.StatusCode);
        }

        [Fact]
        public async Task Invoke_WhenNextThrowsDuplicatedEntityException_ShouldSetResponseCodeTo400()
        {
            var ctx = new DefaultHttpContext();
            _requestDelegate.Setup(next => next(ctx)).ThrowsAsync(new DuplicatedEntityException());

            await _middleware.Invoke(ctx);

            Assert.Equal((int)HttpStatusCode.BadRequest, ctx.Response.StatusCode);
        }

        [Fact]
        public async Task Invoke_WhenNextThrowsUnhandledExceptions_ShouldSetResponseCodeTo500()
        {
            var ctx = new DefaultHttpContext();
            _requestDelegate.Setup(next => next(ctx)).ThrowsAsync(new Exception());

            await _middleware.Invoke(ctx);

            Assert.Equal((int)HttpStatusCode.InternalServerError, ctx.Response.StatusCode);
        }

        [Fact]
        public async Task Invoke_WhenNextRunsNormally_ShouldSetResponseCodeTo200()
        {
            var ctx = new DefaultHttpContext();

            await _middleware.Invoke(ctx);

            Assert.Equal((int)HttpStatusCode.OK, ctx.Response.StatusCode);
        }
    }
}
