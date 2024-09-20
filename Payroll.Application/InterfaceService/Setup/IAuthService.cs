using Payroll.Application.DTOs.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.InterfaceService.Setup
{
    public interface IAuthService
    {
        Task<LoginResponseDTOs> AuthenticateAsync(LoginRequestDTOs request);
    }
}
