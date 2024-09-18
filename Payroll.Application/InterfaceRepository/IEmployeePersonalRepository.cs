
using Payroll.Domain.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.InterfaceRepository
{
    public interface IEmployeePersonalRepository
    {
        Task<List<EmployeePersonal>> GetEmployeePersonalList();
        public Task InsertEmployeePersonal(EmployeePersonal employeePersonal);
    }
}
