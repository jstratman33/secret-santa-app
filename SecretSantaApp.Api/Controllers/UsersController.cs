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
            var existingUser = _userService.GetBySocialId(request.SocialId);
            if (existingUser != null) return Ok(existingUser);

            var user = new User
            {
                SocialId = request.SocialId,
                EmailAddress = request.EmailAddress,
                Name = request.Name
            };
            _userService.Create(user);
            var newUser = _userService.GetBySocialId(request.SocialId);
            return Ok(newUser);
        }
    }
}