using AutoMapper;
using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Queries.GetList
{
    public class GetListUserAccountQuery:IRequest<Paginate<UserAccountResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListUserAccountQueryHandler : IRequestHandler<GetListUserAccountQuery, Paginate<UserAccountResponse>>
        {
            private readonly IUserAccountInfoRepository _userAccountInfoRepository;
            private readonly IMapper _mapper;

            public GetListUserAccountQueryHandler(IUserAccountInfoRepository userAccountInfoRepository, IMapper mapper)
            {
                _userAccountInfoRepository = userAccountInfoRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<UserAccountResponse>> Handle(GetListUserAccountQuery request, CancellationToken cancellationToken)
            {
                var userAccount = await _userAccountInfoRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        cancellationToken:cancellationToken
                    );

                var response = _mapper.Map<Paginate<UserAccountResponse>>(userAccount);
                return response;
            }
        }
    }
}
