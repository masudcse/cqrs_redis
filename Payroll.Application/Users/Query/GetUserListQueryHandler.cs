using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Users.Query
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IDistributedCache _cache;
        public GetUserListQueryHandler(IUserRepository userRepository,IDistributedCache cache)
        {
            _userRepository = userRepository;
            _cache = cache;
        }
        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = "userList";
            List<User> users;
            var cachedUsers = await _cache.GetStringAsync(cacheKey);
            if (!string.IsNullOrEmpty(cachedUsers))
            {
                // Deserialize cached data
                users = JsonConvert.DeserializeObject<List<User>>(cachedUsers);
            }
            else
            {
                // Fetch data from the database and cache it
                users = await _userRepository.GetUserListAysnc();
                var serializedUsers = JsonConvert.SerializeObject(users);
                var cacheOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
                };

                // Store data in Redis
                await _cache.SetStringAsync(cacheKey, serializedUsers, cacheOptions);
            }
            return users;
        }
    }
}
