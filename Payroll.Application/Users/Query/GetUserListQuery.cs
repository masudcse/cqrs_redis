using MediatR;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Users.Query
{
    public class GetUserListQuery:IRequest<List<User>>
    {

    }
}
