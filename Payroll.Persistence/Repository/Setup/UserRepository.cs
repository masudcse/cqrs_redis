using Microsoft.EntityFrameworkCore;
using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Domain.Entities.Setup;
using Payroll.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Persistence.Repository.Setup
{
    public class UserRepository : IUserRepository
    {
        private readonly PayrollDBContext _payrollDBContext;
        public UserRepository(PayrollDBContext payrollDBContext)
        {
            _payrollDBContext = payrollDBContext;
        }

        public async Task<List<User>> GetUserListAysnc()
        {
            return await _payrollDBContext.Users.ToListAsync();
        }

        public async Task AddUserAsync(User user)
        {
            await _payrollDBContext.Users.AddAsync(user);
            await _payrollDBContext.SaveChangesAsync();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            var user = await _payrollDBContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password & u.IsActive.Equals(true));
            return user;
        }
    }
}
