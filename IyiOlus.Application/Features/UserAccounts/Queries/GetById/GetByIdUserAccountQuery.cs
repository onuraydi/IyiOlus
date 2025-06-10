using AutoMapper;
using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Application.Features.UserAccounts.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Queries.GetById
{
    public class GetByIdUserAccountQuery:IRequest<UserAccountResponse>
    {
        public Guid UserAccountId { get; set; }

        public class GetByIdUserAccountQueryHandler : IRequestHandler<GetByIdUserAccountQuery, UserAccountResponse>
        {
            private readonly IUserAccountInfoRepository _userAccountInfoRepository;
            private readonly IMapper _mapper;
            private readonly UserAccountBusinessRules _userAccountBusinessRules;

            public GetByIdUserAccountQueryHandler(IUserAccountInfoRepository userAccountInfoRepository, IMapper mapper, UserAccountBusinessRules userAccountBusinessRules)
            {
                _userAccountInfoRepository = userAccountInfoRepository;
                _mapper = mapper;
                _userAccountBusinessRules = userAccountBusinessRules;
            }

            public async Task<UserAccountResponse> Handle(GetByIdUserAccountQuery request, CancellationToken cancellationToken)
            {
                await _userAccountBusinessRules.UserAccountNotFound(request.UserAccountId);

                var userAccount = await _userAccountInfoRepository.GetAsync(ua => ua.Id == request.UserAccountId);

                var response = _mapper.Map<UserAccountResponse>(userAccount);
                return response;
            }
        }
    }
}
