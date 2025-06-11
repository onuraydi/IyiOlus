using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Constants;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Commands.Delete
{
    public class DeleteUserProfileCommand:IRequest<DeletedUserProfileResponse>
    {
        public Guid userProfileId { get; set; }

        public class DeleteUserProfileCommandRequest : IRequestHandler<DeleteUserProfileCommand, DeletedUserProfileResponse>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public DeleteUserProfileCommandRequest(IUserProfileRepository userProfileRepository, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<DeletedUserProfileResponse> Handle(DeleteUserProfileCommand request, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileNotFound(request.userProfileId);

                var userProfile = await _userProfileRepository.GetAsync(up => up.Id == request.userProfileId);

                if(userProfile != null)
                    await _userProfileRepository.DeleteAsync(userProfile);

                return new DeletedUserProfileResponse
                {
                    Id = request.userProfileId,
                    Message = UserProfileMessages.UserProfileDeleted,
                };
            }
        }
    }
}
