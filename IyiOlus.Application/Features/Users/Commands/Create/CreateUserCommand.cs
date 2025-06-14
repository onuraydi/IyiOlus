using AutoMapper;
using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Features.Users.Dtos.Requests;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Commands.Create
{
    public class CreateUserCommand:IRequest<CreatedUserResponse>
    {
        public CreateUserRequest Request { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreatedUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<CreatedUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                _userBusinessRules.NameShort(command.Request.Name);
                _userBusinessRules.NameLong(command.Request.Name);

                _userBusinessRules.SurnameShort(command.Request.Surname);
                _userBusinessRules.SurnameLong(command.Request.Surname);

                var user = _mapper.Map<User>(command.Request);
                user.ApplicationUserId = command.Request.UserAuthId;
                var createdUser = await _userRepository.AddAsync(user);

                var response = _mapper.Map<CreatedUserResponse>(createdUser);
                response.Message = UserMessages.UserCreated;
                return response;
            }
        }
    }
}
