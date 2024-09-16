using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.DTOs.Payroll
{
    public class EmployeePersonalDTOs
    {
        public int EmployeePersonalId { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
