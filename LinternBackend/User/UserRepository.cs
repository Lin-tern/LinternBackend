using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinternBackend.Token;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinternBackend.User
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signinManager;

        public UserRepository(
            UserManager<AppUser> userManager,
            ITokenService tokenService,
            SignInManager<AppUser> signinManager
        )
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<(AppUser? User, string? ErrorMessage)> createUser(string email, string password)
        {
            try
            {
                var currentUser = new AppUser
                {
                    Email = email,
                    UserName = email
                };
                var createuser = await _userManager.CreateAsync(currentUser, password);
                if (createuser.Succeeded)
                {
                    var RoleResult = await _userManager.AddToRoleAsync(currentUser, "User");
                    var userRole = await _userManager.GetRolesAsync(currentUser);

                    if (RoleResult.Succeeded)
                    {
                        return (currentUser, null);
                    }
                    else
                    {
                        var errors = string.Join("; ", RoleResult.Errors.Select(e => e.Description));
                        return (null, $"user created but role assignment failed: {errors}");
                    }
                }
                else
                {
                    var errors = string.Join("; ", createuser.Errors.Select(e => e.Description));
                    return (null, $"User creation failed: {errors}");
                }
            }
            catch (Exception ex)
            {
                return (null, $"Unexpected error: {ex.Message}");

            }
        }

        public async Task<(AppUser? User, string? ErrorMessage)> loginUser(string email, string password)
        {
            try
            {
                var currentUser = await _userManager.FindByEmailAsync(email);
                if (currentUser == null) return (null, "Invalid Username or Password");

                var result = await _signinManager.CheckPasswordSignInAsync(currentUser, password, false);
                if (!result.Succeeded) return (null, "Invalid Username or Password");

                var userRole = await _userManager.GetRolesAsync(currentUser);
                return (currentUser, "Login Succesful");

            }
            catch (Exception ex)
            {
                return (null, $"Unexpected error: {ex.Message}");
            }
        }

        public async Task<string?> token(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;
            var userRole = await _userManager.GetRolesAsync(user);
            var token = _tokenService.CreateToken(user, userRole);

            return token;
        }
    }
}