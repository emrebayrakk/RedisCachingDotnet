using RedisCachingDotnet.Models;

namespace RedisCachingDotnet.Repository
{
    public interface IUserRepository
    {
        Task<long> AddUser(User user);
        Task<List<User>> GetUsers();
    }
}
