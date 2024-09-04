using Microsoft.EntityFrameworkCore;
using RedisCachingDotnet.Context;
using RedisCachingDotnet.Models;

namespace RedisCachingDotnet.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RedisCachingDotnetContext _dbContext;

        public UserRepository(RedisCachingDotnetContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> AddUser(User user)
        {
            _dbContext.Users.Add(user);
            var response = await _dbContext.SaveChangesAsync();
            return response;
        }

        public async Task<List<User>> GetUsers()
        {
            var response = await _dbContext.Users.ToListAsync();
            return response;
        }
    }
}
