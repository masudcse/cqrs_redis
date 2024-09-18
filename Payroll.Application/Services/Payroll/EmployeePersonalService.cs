using Payroll.Application.DTOs.Payroll;
using Payroll.Application.InterfaceRepository;
using Payroll.Application.InterfaceService.Payroll;
using Payroll.Domain.Entities.Payroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Services.Payroll
{
    public class EmployeePersonalService : IEmployeePersonalService
    {
        private readonly IEmployeePersonalRepository _employeePersonalRepository;
        public EmployeePersonalService(IEmployeePersonalRepository employeePersonalRepository)
        {
            _employeePersonalRepository = employeePersonalRepository;
        }

        public async Task<List<EmployeePersonalDTOs>> GetEmployeePersonalList()
        {
            var employeePersonal = await _employeePersonalRepository.GetEmployeePersonalList();
            return employeePersonal.Select(x => new EmployeePersonalDTOs
            {
                EmployeePersonalId = x.EmployeePersonalId,
                EmployeeName = x.EmployeeName,
                Address = x.Address,
                IsActive = x.IsActive,
                ContactNo = x.ContactNo,
                Gender = x.Gender
            }).ToList();
        }

        public Task InsertEmployeePersonal(EmployeePersonalDTOs employeePersonalDTOs)
        {
            //later will use automapper nuget package
            var employeePersonal = new EmployeePersonal
            {
                EmployeeName = employeePersonalDTOs.EmployeeName,
                Address = employeePersonalDTOs.Address,
                ContactNo = employeePersonalDTOs.ContactNo,
                Gender = employeePersonalDTOs.Gender,
                IsActive = employeePersonalDTOs.IsActive,
                CreatedBy = 1,
                CreatedOn = DateTime.Today,
                UpdatedOn = DateTime.Today
            };

            return _employeePersonalRepository.InsertEmployeePersonal(employeePersonal);
        }
    }
}
