﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Personal.Control.Models.Requests;
using Personal.Control.Models.Responses;
using Personal.Control.Services.Models;
using Personal.Control.Services.Services.Interfaces;
using Personal.Control.Utils.Exceptions;
using Personal.Control.Validators;

namespace Personal.Control.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        /// <summary>
        /// Retrive data from a registered user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Register a user to use the system
        /// </summary>
        /// <param name="request">A request to create an user</param>
        /// <returns>Id of created user</returns>
        /// <exception cref="ArgumentException">Any attribute of request with validation issues</exception>
        /// <exception cref="ArgumentOutOfRangeException">Password out of size range</exception>
        /// <exception cref="DuplicatedEntityException">User already registered</exception>
        [HttpPut]
        public async Task<IActionResult> Register(UserRequest request)
        {
            request.Validate();
            var user = _mapper.Map<User>(request);
            var registeredUser = await _userService.RegisterAsync(user);
            var response = _mapper.Map<UserResponse>(registeredUser);
            return Ok(response);
        }

        /// <summary>
        /// Resets a user password
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost]
        [Route("password/reset")]
        public IActionResult ResetPassword()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the user from the system
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrive user permissions
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet]
        [Route("{id}/permissions")]
        public IActionResult GetPermissions(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update data of an user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}")]
        public IActionResult Update(string id)
        {
            throw new NotImplementedException();
        }
    }
}