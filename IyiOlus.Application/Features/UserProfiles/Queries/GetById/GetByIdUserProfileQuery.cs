using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Queries.GetById
{
    public class GetByIdUserProfileQuery:IRequest<UserProfileResponse>
    {
        public Guid UserProfileId { get; set; }
        public class GetByIdUserProfileQueryHandler : IRequestHandler<GetByIdUserProfileQuery, UserProfileResponse>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;

            public GetByIdUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
            }

            public async Task<UserProfileResponse> Handle(GetByIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileNotFound(request.UserProfileId);

                var userProfile = await _userProfileRepository.GetAsync(
                    predicate: up => up.Id == request.UserProfileId,
                    include: x => x.Include(y => y.User).ThenInclude(x => x.ApplicationUser).Include(y => y.ProfileType),
                    cancellationToken: cancellationToken);

                var response = _mapper.Map<UserProfileResponse>(userProfile);
                return response;
            }
        }
    }
}
