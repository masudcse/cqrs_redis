
using Payroll.Application.InterfaceRepository;
using Payroll.Domain.Entities.Payroll;
using Payroll.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Persistence.Repository.Payroll
{
    public class EmployeePersonalRepository : IEmployeePersonalRepository
    {
        private readonly PayrollDBContext _dbContext;
        public EmployeePersonalRepository(PayrollDBContext payrollDBContext)
        {
            _dbContext = payrollDBContext;
        }
        public async Task InsertEmployeePersonal(EmployeePersonal employeePersonal)
        {
            await _dbContext.EmployeePersonals.AddAsync(employeePersonal);
            await _dbContext.SaveChangesAsync();
        }
    }
}
