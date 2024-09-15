using Payroll.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities.Payroll
{
    public class EmployeeOfficial : BaseEntity
    {
        [Key]
        public int EmployeeOfficialId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int GradeId { get; set; }
        public bool isManagement {  get; set; }
        public EmployeePersonal EmployeePersonal { get; set; }
    }
}
