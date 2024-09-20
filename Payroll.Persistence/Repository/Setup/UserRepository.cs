using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Persistence.Repository.Setup
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User {
                Username = "test", Password = "password"
            }
        };

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return await Task.FromResult(user);
        }
    }
}
