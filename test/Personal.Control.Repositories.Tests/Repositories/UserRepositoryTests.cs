﻿using AutoFixture;
using Personal.Control.Repositories.Models;
using Personal.Control.Repositories.Repositories;
using Personal.Control.Repositories.Repositories.Interfaces;
using Personal.Control.Utils.Exceptions;
using Xunit;

namespace Personal.Control.Repositories.Tests.Repositories
{
    public class UserRepositoryTests
    {
        private readonly Fixture _fixture;
        private readonly TestDbContextFactory _dbContextFactory;
        private readonly IUserRepository _userRepository;
        public UserRepositoryTests()
        {
            _fixture = new Fixture();
            _dbContextFactory = new TestDbContextFactory();
            _userRepository = new UserRepository(_dbContextFactory);
        }

        [Fact]
        public async Task SaveAsync_WhenCallForNewUser_ShouldSaveChanges()
        {
            var user = _fixture.Create<User>();
            await _userRepository.SaveAsync(user);

            using var context = _dbContextFactory.CreateDbContext();
            var savedUser = await context.Users.FindAsync(user.Id);

            Assert.Equal(savedUser?.Email, user.Email);
        }

        [Fact]
        public async Task SaveAsync_WhenCallForExistingUser_ShouldThrowException()
        {
            var user = _fixture.Create<User>();
            await _userRepository.SaveAsync(user);
            user.Password += "a";
            await Assert.ThrowsAsync<DuplicatedEntityException>(() => _userRepository.SaveAsync(user));
        }

        [Fact]
        public async Task GetAsync_WhenExistingUser_ShouldReturnIt()
        {
            var user = _fixture.Create<User>();
            await _userRepository.SaveAsync(user);
            var returnedUser = await _userRepository.GetAsync(user.Id);
            Assert.Equal(user.Email, returnedUser?.Email);
            Assert.Equal(user.Id, returnedUser?.Id);
            Assert.Equal(user.Password, returnedUser?.Password);
        }

        [Fact]
        public async Task GetAsync_WhenNonExistingUser_ShouldReturnNull()
        {
            var id = _fixture.Create<string>();
            var returnedUser = await _userRepository.GetAsync(id);
            Assert.Null(returnedUser);
        }
    }
}
