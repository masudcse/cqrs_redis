using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Domain.Entities.Setup
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public bool Active { get; set; }
    }
}
