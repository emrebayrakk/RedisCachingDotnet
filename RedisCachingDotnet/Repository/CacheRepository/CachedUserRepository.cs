using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisCachingDotnet.Models;

namespace RedisCachingDotnet.Repository.CacheRepository
{
    public class CachedUserRepository : IUserRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly IDistributedCache _distributedCache;

        public CachedUserRepository(IUserRepository userRepository, IDistributedCache distributedCache)
        {
            _userRepository = userRepository;
            _distributedCache = distributedCache;
        }

        public Task<long> AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public async Task<List<User>> GetUsers()
        {
            string key = "getall";
            string? cachedUser = await _distributedCache.GetStringAsync(
                key);
            List<User> user;
            if (string.IsNullOrEmpty(cachedUser))
            {
                user = _userRepository.GetUsers().Result;
                if (user == null) {
                    return user;
                }
                await _distributedCache.SetStringAsync(key,
                    JsonConvert.SerializeObject(user));

                return user;
            }
            user = JsonConvert.DeserializeObject<List<User>>(cachedUser);
            return user;
        }
    }
}
