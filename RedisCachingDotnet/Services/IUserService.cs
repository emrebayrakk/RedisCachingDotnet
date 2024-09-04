using RedisCachingDotnet.Models;
using RedisCachingDotnet.Utils;

namespace RedisCachingDotnet.Services
{
    public interface IUserService
    {
        ApiResponse<long> CreateUser(User user);
        ApiResponse<List<User>> UserList();
    }
}
