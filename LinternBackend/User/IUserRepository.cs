using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.User
{
    public interface IUserRepository
    {
        public Task<(AppUser? User, string? ErrorMessage)> createUser(string Email, string Password);
        public Task<(AppUser? User, string? ErrorMessage)> loginUser(string Email, string Password);
        public Task<String?> token(string userId);
    }
}