using IoTWebAPI.DTOs.Users;
using IoTWebAPI.Helpers;
using IoTWebAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public class UserService : IUsers
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleInManager;
        private readonly IConfiguration  _config;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleInManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleInManager = roleInManager;
            _config = config;
        }

        public async Task<AuthViewModel> Login(string email, string password/*, bool rememberMe*/)
        {
            //throw new NotImplementedException();
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                throw new CustomException("Not found this User");
            var res = await _signInManager.PasswordSignInAsync(user, password, false, false);  //F-F : RememberMe - Login fail nhieu khong khoa
            if (!res.Succeeded)
                return null;

            var role = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.fullname),
                new Claim(ClaimTypes.Role, string.Join(";", role))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new AuthViewModel
            {
                id = user.Id,
                email = user.Email,
                fullname = user.fullname,
                is_active = user.is_active,
                create_date = user.create_date,
                token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task Logout()
        {
            //throw new NotImplementedException();
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            //throw new NotImplementedException();
           
            if (await _userManager.FindByEmailAsync(request.email) != null)
            {
                throw new CustomException("Email DA TON TAI!");
            }

            var user = new User()
            {
                Email = request.email,
                fullname = request.fullname,
                create_date = DateTime.Now.Date,
                is_active = true,
                is_admin = false
            };
            var res = await _userManager.CreateAsync(user, request.Password);
            //if (res.Succeeded)
            //{
            //    return true;
            //}
            //return false;
            if (request.Password == request.ConfirmPassword && res.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
