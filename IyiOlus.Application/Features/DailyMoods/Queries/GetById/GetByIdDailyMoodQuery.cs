using AutoMapper;
using IyiOlus.Application.Features.DailyMoods.Dtos.Responses;
using IyiOlus.Application.Features.DailyMoods.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Queries.GetById
{
    public class GetByIdDailyMoodQuery:IRequest<DailyMoodResponse>
    {
        public Guid DailyMoodId { get; set; }

        public class GetByIdDailyMoodQueryHandler : IRequestHandler<GetByIdDailyMoodQuery, DailyMoodResponse>
        {
            private readonly IDailyMoodRepository _dailyMoodRepository;
            private readonly IMapper _mapper;
            private readonly DailyMoodBusinessRules _dailyMoodBusinessRules;

            public GetByIdDailyMoodQueryHandler(IDailyMoodRepository dailyMoodRepository, IMapper mapper, DailyMoodBusinessRules dailyMoodBusinessRules)
            {
                _dailyMoodRepository = dailyMoodRepository;
                _mapper = mapper;
                _dailyMoodBusinessRules = dailyMoodBusinessRules;
            }

            public async Task<DailyMoodResponse> Handle(GetByIdDailyMoodQuery request, CancellationToken cancellationToken)
            {
                await _dailyMoodBusinessRules.DailyMoodNotFound(request.DailyMoodId);

                var dailyMood = await _dailyMoodRepository.GetAsync(
                    predicate: dm => dm.Id == request.DailyMoodId,
                    include: x => x.Include(y => y.User),
                    cancellationToken: cancellationToken);

                var response = _mapper.Map<DailyMoodResponse>(dailyMood);
                return response;
            }
        }
    }
}
