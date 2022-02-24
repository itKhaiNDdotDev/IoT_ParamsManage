using IoTWebAPI.DTOs.Users;
using IoTWebAPI.Models;
using IoTWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _userService;
        public UsersController(IUsers userService)
        {
            _userService = userService;
        }

        [HttpPost("logint")]
        [AllowAnonymous]
        public async Task<IActionResult> LogIn(string email, string password)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _userService.Login(email, password);
            if (res == null)
            {
                return BadRequest("Failed roi!");
            }
            return Ok(res);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await _userService.Register(request);
            if (!res)
            {
                return BadRequest("RegisterFailed!");
            }
            return Ok("Created!");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
           await _userService.Logout();
            return Ok();
        }
    }
}
