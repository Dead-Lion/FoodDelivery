using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using AutoMapper;
using FoodDelivery.Models;
using FoodDelivery.Services;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Controllers
{
    [Route("Users")]
    public class UsersController
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Create a new User
        /// </summary>
        [HttpPost]
        [Route("")]
        public async Task Create([FromBody]UserView model)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserView, User>());
            User user = Mapper.Map<UserView, User>(model);
            user.Guid = Guid.NewGuid();

            await _userService.Create(user);
        }

        /// <summary>
        /// Update User
        /// </summary>
        [HttpPut]
        [Route("{userGuid}")]
        public async Task Update(Guid userGuid, [FromBody]UserView model)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<UserView, User>());
            User user = Mapper.Map<UserView, User>(model);
            user.Guid = userGuid;

            await _userService.Update(user);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        [HttpDelete]
        [Route("{userGuid}")]
        public async Task Delete(Guid userGuid)
        {
            await _userService.Delete(userGuid);
        }

        /// <summary>
        /// Get user
        /// </summary>
        [HttpGet]
        [Route("{userGuid}")]
        public Task<User> GetUser(Guid userGuid)
        {
            return _userService.GetUser(userGuid);
        }

        /// <summary>
        /// Get a List of Users
        /// </summary>
        [HttpGet]
        [Route("")]
        public List<User> GetUsers()
        {
            return _userService.GetUsers();
        }
    }
}