using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.InterfaceRepository.Setup
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserListAysnc();
        Task<User> ValidateUserAsync(string username, string password);
        Task AddUserAsync(User user);
    }
}
