using AutoMapper;
using IyiOlus.Application.Features.DailyMoods.Constants;
using IyiOlus.Application.Features.DailyMoods.Dtos.Requests;
using IyiOlus.Application.Features.DailyMoods.Dtos.Responses;
using IyiOlus.Application.Features.DailyMoods.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Commands.Create
{
    public class CreateDailyMoodCommand:IRequest<CreatedDailyMoodResponse>
    {
        public CreateDailyMoodRequest Request { get; set; } = default!;

        public class CreateDailyMoodCommandHandler : IRequestHandler<CreateDailyMoodCommand, CreatedDailyMoodResponse>
        {
            private readonly IDailyMoodRepository _dailyMoodRepository;
            private readonly IMapper _mapper;
            private readonly DailyMoodBusinessRules _dailyMoodBusinessRules;

            public CreateDailyMoodCommandHandler(IDailyMoodRepository dailyMoodRepository, IMapper mapper, DailyMoodBusinessRules dailyMoodBusinessRules)
            {
                _dailyMoodRepository = dailyMoodRepository;
                _mapper = mapper;
                _dailyMoodBusinessRules = dailyMoodBusinessRules;
            }

            public async Task<CreatedDailyMoodResponse> Handle(CreateDailyMoodCommand command, CancellationToken cancellationToken)
            {
                var dailyMood = _mapper.Map<DailyMood>(command.Request);

                var createdDailyMood = await _dailyMoodRepository.AddAsync(dailyMood);

                var response = _mapper.Map<CreatedDailyMoodResponse>(createdDailyMood);
                response.Message = DailyMoodMessages.DailyMoodCreated;
                return response;
            }
        }
    }
}
