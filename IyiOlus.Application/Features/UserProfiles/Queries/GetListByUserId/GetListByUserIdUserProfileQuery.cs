using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
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
        public Guid UserId { get; set; }


        public class GetListByUserIdUserProfileQueryHandler : IRequestHandler<GetListByUserIdUserProfileQuery, Paginate<UserProfileResponse>>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;

            public GetListByUserIdUserProfileQueryHandler(IUserProfileRepository userProfileRepository, IMapper mapper)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<UserProfileResponse>> Handle(GetListByUserIdUserProfileQuery request, CancellationToken cancellationToken)
            {
                var userProfiles = await _userProfileRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        predicate: u => u.UserId == request.UserId,
                        //include: u=> u.Include(x => x.)
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<UserProfileResponse>>(userProfiles);
                return response;
            }
        }
    }
}
