using AutoMapper;
using IyiOlus.Application.Features.DailyMoods.Dtos.Responses;
using IyiOlus.Application.Features.DailyMoods.Rules;
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

namespace IyiOlus.Application.Features.DailyMoods.Queries.GetListDailyMoodByUserId
{
    public class GetListDailyMoodByUserIdCommand:IRequest<Paginate<DailyMoodResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public class GetListDailyMoodByUserIdCommandHandler : IRequestHandler<GetListDailyMoodByUserIdCommand, Paginate<DailyMoodResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IDailyMoodRepository _dailyMoodRepository;
            private readonly DailyMoodBusinessRules _dailyMoodBusinessRules;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public GetListDailyMoodByUserIdCommandHandler(IMapper mapper, IDailyMoodRepository dailyMoodRepository, DailyMoodBusinessRules dailyMoodBusinessRules, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _mapper = mapper;
                _dailyMoodRepository = dailyMoodRepository;
                _dailyMoodBusinessRules = dailyMoodBusinessRules;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<DailyMoodResponse>> Handle(GetListDailyMoodByUserIdCommand request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var dailyMood = await _dailyMoodRepository.GetListAsync(
                        predicate: x => x.UserId == userId,
                        index: request.PageIndex,
                        size: request.PageSize,
                        include: u => u.Include(x => x.User),
                        cancellationToken: cancellationToken);

                var response = _mapper.Map<Paginate<DailyMoodResponse>>(dailyMood);
                return response;
            }
        }
    }
}
