using AutoMapper;
using IyiOlus.Application.Features.Statistics.UserProfilesStatistics.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Statistics.UserProfilesStatistics.Queries
{
    public class UserProfilesStatisticQuery:IRequest<Paginate<UserProfilesStatisticResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public class UserProfilesStatisticQueryHandler : IRequestHandler<UserProfilesStatisticQuery, Paginate<UserProfilesStatisticResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public UserProfilesStatisticQueryHandler(IMapper mapper, IUserProfileRepository userProfileRepository, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<UserProfilesStatisticResponse>> Handle(UserProfilesStatisticQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var userProfiles = await _userProfileRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    predicate: x => x.UserId == userId,
                    orderBy: x => x.OrderBy(x => x.ProfileTestDate),
                    include: x => x.Include(x => x.ProfileType),
                    cancellationToken: cancellationToken 
                );

                var response = _mapper.Map<Paginate<UserProfilesStatisticResponse>>(userProfiles);
                return response;
            }
        }
    }
}
