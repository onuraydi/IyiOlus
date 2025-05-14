using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Constants;
using IyiOlus.Application.Features.UserProfiles.Dtos.Requests;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Commands.Create
{
    public class CreateUserProfileCommand:IRequest<CreatedUserProfileResponse>
    {
        public CreateUserProfileRequest Request { get; set; } = default!;

        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileResponse>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<CreatedUserProfileResponse> Handle(CreateUserProfileCommand command, CancellationToken cancellationToken)
            {
                //await _userProfileBusinessRules.UserProfileBlock(command.Request.userId, command.Request.ProfileTestDate); // ilişkiden sonra açılacak
                await _userProfileBusinessRules.UserProfileNotPossible();

                var userProfile = _mapper.Map<UserProfile>(command.Request);
                var createdUserProfile = await _userProfileRepository.AddAsync(userProfile);

                var response = _mapper.Map<CreatedUserProfileResponse>(createdUserProfile);
                response.Message = UserProfileMessages.UserProfileCreated;
                return response;
            }
        }
    }
}
