using AutoMapper;
using IyiOlus.Application.Features.Statistics.DailyMoodStatistics.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;

namespace IyiOlus.Application.Features.Statistics.DailyMoodStatistics.Queries
{
    public class DailyMoodStatisticQuery:IRequest<Paginate<DailyMoodStatisticResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public class DailyMoodStatisticQueryHandler : IRequestHandler<DailyMoodStatisticQuery, Paginate<DailyMoodStatisticResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IDailyMoodRepository _dailyMoodRepository;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public DailyMoodStatisticQueryHandler(IMapper mapper, IDailyMoodRepository dailyMoodRepository, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _mapper = mapper;
                _dailyMoodRepository = dailyMoodRepository;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<DailyMoodStatisticResponse>> Handle(DailyMoodStatisticQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var statistic = await _dailyMoodRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    predicate: x => x.UserId == userId,
                    orderBy: x => x.OrderBy(x => x.Date),
                    cancellationToken: cancellationToken
                );

                var response = _mapper.Map<Paginate<DailyMoodStatisticResponse>>(statistic);

                return response;
            }
        }
    }
}
