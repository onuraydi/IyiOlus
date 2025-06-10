using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Constants;
using IyiOlus.Application.Features.UserProfiles.Dtos.Requests;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Commands.Update
{
    public class UpdateUserProfileCommand:IRequest<UpdatedUserProfileResponse>
    {
        public UpdateUserProfileRequest Request { get; set; } = default!;

        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileResponse>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<UpdatedUserProfileResponse> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileNotFound(command.Request.UserProfileId);
                await _userProfileBusinessRules.UserProfileNotPossible();
                //await _userProfileBusinessRules.UserProfileBlock(command.Request.UserId, command.Request.ProfileTestDate);

                var userProfile = await _userProfileRepository.GetAsync(up => up.Id == command.Request.UserProfileId);

                var updatedUserProfile = await _userProfileRepository.UpdateAsync(userProfile);

                var response = _mapper.Map<UpdatedUserProfileResponse>(updatedUserProfile);
                response.Message = UserProfileMessages.UserProfileUpdated;

                return response;
            }
        }
    }
}
