using AutoMapper;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
using IyiOlus.Application.Features.Exercises.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Queries.GetById
{
    public class GetByIdExerciseQuery:IRequest<ExerciseResponse>
    {
        public Guid ExerciseId { get; set; }
        public class GetByIdExerciseQueryHandler : IRequestHandler<GetByIdExerciseQuery, ExerciseResponse>
        {
            private readonly IExerciseRepository _exerciseRepository;
            private readonly IMapper _mapper;
            private readonly ExerciseBusinesssRules _exerciseBusinesssRules;

            public GetByIdExerciseQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper, ExerciseBusinesssRules exerciseBusinesssRules)
            {
                _exerciseRepository = exerciseRepository;
                _mapper = mapper;
                _exerciseBusinesssRules = exerciseBusinesssRules;
            }

            public async Task<ExerciseResponse> Handle(GetByIdExerciseQuery command, CancellationToken cancellationToken)
            {
                await _exerciseBusinesssRules.ExerciseNotFound(command.ExerciseId);

                var exercise = await _exerciseRepository.GetAsync(
                    predicate: x => x.Id == command.ExerciseId,
                    include: x => x.Include(y => y.User),
                    cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<ExerciseResponse>(exercise);
                return response;
            }
        }
    }
}
