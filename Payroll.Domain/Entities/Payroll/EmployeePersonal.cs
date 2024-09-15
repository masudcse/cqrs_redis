using Payroll.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities.Payroll
{
    public class EmployeePersonal : BaseEntity
    {
        [Key]
        public int EmployeePersonalId { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
