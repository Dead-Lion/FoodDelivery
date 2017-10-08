using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodDelivery.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Controllers
{
    [Route("Users")]
    public class UsersController
    {
        private readonly ApplicationContext _dbContext;

        public UsersController(ApplicationContext context)
        {
            _dbContext = context;
        }

        /// <summary>
        /// Create a new User
        /// </summary>
        [HttpPost]
        [Route("Create")]
        public async Task Create([FromBody]User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update User
        /// </summary>
        [HttpPut]
        [Route("Update")]
        public async Task Update([FromBody]User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete User!
        /// </summary>
        /// <param name="userGuid"></param>
        [HttpDelete]
        [Route("Delete")]
        public async Task Delete([FromBody]Guid userGuid)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(p => p.Guid == userGuid);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get a List of Users
        /// </summary>
        [HttpGet]
        [Route("GetUsers")]
        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}