using AutoMapper;
using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Features.Users.Dtos.Requests;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Commands.Update
{
    public class UpdateUserCommand:IRequest<UpdatedUserResponse>
    {
        public UpdateUserRequest Request { get; set; } = default!;

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdatedUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UpdatedUserResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserNotFound(command.Request.Id);
                _userBusinessRules.NameShort(command.Request.Name);
                _userBusinessRules.NameLong(command.Request.Name);
                _userBusinessRules.SurnameShort(command.Request.Surname);
                _userBusinessRules.SurnameLong(command.Request.Surname);

                var user = await _userRepository.GetAsync(u => u.Id == command.Request.Id);
                _mapper.Map(command.Request, user);
               
                var updatedUser = await _userRepository.UpdateAsync(user);

                var response = _mapper.Map<UpdatedUserResponse>(updatedUser);
                response.Message = UserMessages.UserUpdated;

                return response;
            }
        }
    }
}
