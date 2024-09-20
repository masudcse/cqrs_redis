using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.DTOs.Setup
{
    public class LoginResponseDTOs
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
