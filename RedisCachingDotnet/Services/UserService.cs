using RedisCachingDotnet.Models;
using RedisCachingDotnet.Repository;
using RedisCachingDotnet.Utils;

namespace RedisCachingDotnet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ApiResponse<long> CreateUser(User user)
        {
            var response = _userRepository.AddUser(user).Result;
            if (response != -1)
                return new ApiResponse<long>(true, 200, "Success", response);
            return new ApiResponse<long>(false, 500, "ErrorOccured", -1);
        }

        public ApiResponse<List<User>> UserList()
        {
            var result = _userRepository.GetUsers().Result;
            return new ApiResponse<List<User>>(true, 200, "Success", result);
        }
    }
}
