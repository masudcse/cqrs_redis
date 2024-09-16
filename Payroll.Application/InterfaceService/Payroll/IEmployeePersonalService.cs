using Payroll.Application.DTOs.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.InterfaceService.Payroll
{
    public interface IEmployeePersonalService
    {
        public Task InsertEmployeePersonal(EmployeePersonalDTOs employeePersonalDTOs);
    }
}
