using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
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

namespace IyiOlus.Application.Features.UserProfiles.Queries.GetListByUserId
{
    public class GetListByUserIdUserProfileQuery:IRequest<Paginate<UserProfileResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListByUserIdUserProfileQueryHandler : IRequestHandler<GetListByUserIdUserProfileQuery, Paginate<UserProfileResponse>>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;
            public GetListByUserIdUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<UserProfileResponse>> Handle(GetListByUserIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var userProfiles = await _userProfileRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        predicate: u => u.UserId == userId,
                        include: x => x.Include(y => y.User).ThenInclude(y => y.ApplicationUser).Include(y => y.ProfileType),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<UserProfileResponse>>(userProfiles);
                return response;
            }
        }
    }
}
