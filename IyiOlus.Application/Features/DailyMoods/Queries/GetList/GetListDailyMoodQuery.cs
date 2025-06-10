using AutoMapper;
using IyiOlus.Application.Features.DailyMoods.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Queries.GetList
{
    public class GetListDailyMoodQuery:IRequest<Paginate<DailyMoodResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListDailyMoodQueryHandler : IRequestHandler<GetListDailyMoodQuery, Paginate<DailyMoodResponse>>
        {
            private readonly IDailyMoodRepository _dailyMoodRepository;
            private readonly IMapper _mapper;

            public GetListDailyMoodQueryHandler(IDailyMoodRepository dailyMoodRepository, IMapper mapper)
            {
                _dailyMoodRepository = dailyMoodRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<DailyMoodResponse>> Handle(GetListDailyMoodQuery request, CancellationToken cancellationToken)
            {
                var dailyMoods = await _dailyMoodRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        include: x => x.Include(y => y.User),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<DailyMoodResponse>>(dailyMoods);
                return response;
            }
        }
    }
}
