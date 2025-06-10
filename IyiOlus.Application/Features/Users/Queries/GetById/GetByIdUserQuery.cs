using AutoMapper;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Queries.GetById
{
    public class GetByIdUserQuery:IRequest<UserResponse>
    {
        public Guid UserId { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                await _userBusinessRules.UserNotFound(request.UserId);

                var user = await _userRepository.GetAsync(
                    predicate: u => u.Id == request.UserId,
                    include: u => u.Include(x => x.UserAccountInfo),
                    cancellationToken: cancellationToken);

                var response = _mapper.Map<UserResponse>(user);
                return response;
            }
        }
    }
}
