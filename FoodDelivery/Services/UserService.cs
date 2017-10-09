using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using AutoMapper;
using FoodDelivery.Models;
using FoodDelivery.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Services
{
    public class UserService
    {
        private readonly ApplicationContext _dbContext;

        public UserService(ApplicationContext context)
        {
            _dbContext = context;
        }

        public async Task Create(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid userGuid)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Guid == userGuid);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
            }
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Task<User> GetUser(Guid userGuid)
        {
            var user = _dbContext.Users.FirstOrDefaultAsync(u => u.Guid == userGuid);
            return user;
        }
    }
}
