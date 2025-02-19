﻿using Microsoft.AspNetCore.Mvc;
using MyNewCiniesOction.Models;

namespace MyNewCiniesOction.DAL
{
    public interface IUserDal
    {
        public Task<List<User>> Get();
        public Task<bool> Delete(int userId);
        public Task<bool> PutForUser(User user);
        public Task<bool> PutForAdmin(User user);
        public Task<bool> Post(User user);
        public Task<User> GetUserByEmailAndPassword(string email, string password);
    }
}
