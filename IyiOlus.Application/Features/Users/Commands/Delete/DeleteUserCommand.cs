using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Commands.Delete
{
    public class DeleteUserCommand:IRequest<DeletedUserResponse>
    {
        public Guid UserId { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<DeletedUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserNotFound(request.UserId);

                var user = await _userRepository.GetAsync(u => u.UserId == request.UserId);

                if(user != null)
                    await _userRepository.DeleteAsync(user);

                return new DeletedUserResponse
                {
                    UserId = request.UserId,
                    Message = UserMessages.userDeleted,
                };
            }
        }
    }
}
