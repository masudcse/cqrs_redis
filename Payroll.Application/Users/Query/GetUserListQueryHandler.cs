using MediatR;
using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Users.Query
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        
        public GetUserListQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
          return  await _userRepository.GetUserListAysnc();
        }
    }
}
