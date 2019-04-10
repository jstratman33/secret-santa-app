using Microsoft.AspNetCore.Mvc;
using SecretSantaApp.Api.Models;
using SecretSantaApp.BusinessLogic.Services.Interfaces;
using SecretSantaApp.EfCore.Enitities;

namespace SecretSantaApp.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult HandleUserLogin(UserLoginRequest request)
        {
            var existingUser = _userService.GetByEmailAddress(request.EmailAddress);
            if (existingUser != null) return Ok(existingUser);

            var user = new User
            {
                EmailAddress = request.EmailAddress,
                Name = request.Name
            };
            _userService.Create(user);
            var newUser = _userService.GetByEmailAddress(request.EmailAddress);
            return Ok(newUser);
        }
    }
}