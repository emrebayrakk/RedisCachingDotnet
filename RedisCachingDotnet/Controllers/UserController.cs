using Microsoft.AspNetCore.Mvc;
using RedisCachingDotnet.Models;
using RedisCachingDotnet.Services;
using RedisCachingDotnet.Utils;

namespace RedisCachingDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public ApiResponse<List<User>> GetAllUsers()
        {
            return _userService.UserList();
        }

        [HttpPost("[action]")]
        public ApiResponse<long> Create([FromBody] User user)
        {
            var response = _userService.CreateUser(user);
            return response;
        }
    }
}
