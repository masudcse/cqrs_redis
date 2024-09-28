using MediatR;
using Payroll.Application.InterfaceRepository.Setup;
using Payroll.Domain.Entities.Setup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payroll.Application.Users.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = request.Username,
                Password = request.Password,
                Email = request.Email,
                IsActive = request.IsActive,
                Role = request.Role
            };
            await _userRepository.AddUserAsync(user);
            return user.UserId;
        }
    }
}
