using IoTWebAPI.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public interface IUsers
    {
        Task<AuthViewModel> Login(string email, string password/*, bool rememberMe*/);
        Task<bool> Register(RegisterRequest request);
        Task Logout();
    }
}
