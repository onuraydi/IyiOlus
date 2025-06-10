using AutoMapper;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Queries.GetList
{
    public class GetListUserQuery:IRequest<Paginate<UserResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, Paginate<UserResponse>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<UserResponse>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                var users = await _userRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        include: u => u.Include(x => x.UserAccountInfo),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<UserResponse>>(users);
                return response;
            }
        }
    }
}
