﻿using Personal.Control.Models.Enums;
using Personal.Control.Models.Responses;
using Personal.Control.Utils.Exceptions;
using System.Net;

namespace Personal.Control.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                var response = context.Response;

                var (status, message) = GetResponse(e);
                response.StatusCode = (int)status;
                await response.WriteAsJsonAsync(message);
            }
        }

        private static (HttpStatusCode status, ExceptionResponse message) GetResponse(Exception e)
        {
            var (code, exceptionCode) = e switch
            {
                ArgumentException or ArgumentOutOfRangeException => (HttpStatusCode.BadRequest, ExceptionCodes.InvalidBody),
                DuplicatedEntityException => (HttpStatusCode.BadRequest, ExceptionCodes.AlreadyExists),
                EntityNotFoundException => (HttpStatusCode.NotFound, ExceptionCodes.NotFound),
                _ => (HttpStatusCode.InternalServerError, ExceptionCodes.GenericError),
            };

            return (code, new ExceptionResponse(exceptionCode, e.Message));
        }
    }
}
