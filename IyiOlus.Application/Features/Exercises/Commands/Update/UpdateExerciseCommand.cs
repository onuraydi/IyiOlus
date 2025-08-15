using AutoMapper;
using IyiOlus.Application.Features.Exercises.Constants;
using IyiOlus.Application.Features.Exercises.Dtos.Requests;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
using IyiOlus.Application.Features.Exercises.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Commands.Update
{
    public class UpdateExerciseCommand:IRequest<UpdatedExerciseResponse>
    {
        public UpdateExerciseRequest Request { get; set; } = default!;

        public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand, UpdatedExerciseResponse>
        {
            private readonly IExerciseRepository _exerciseRepository;
            private readonly IMapper _mapper;
            private readonly ExerciseBusinesssRules _exerciseBusinesssRules;

            public UpdateExerciseCommandHandler(IExerciseRepository exerciseRepository, IMapper mapper, ExerciseBusinesssRules exerciseBusinesssRules)
            {
                _exerciseRepository = exerciseRepository;
                _mapper = mapper;
                _exerciseBusinesssRules = exerciseBusinesssRules;
            }

            public async Task<UpdatedExerciseResponse> Handle(UpdateExerciseCommand command, CancellationToken cancellationToken)
            {
                await _exerciseBusinesssRules.ExerciseNotFound(command.Request.Id);
                _exerciseBusinesssRules.ProgressMaxAndMinValueError(command.Request.Progress);

                var exercise = await _exerciseRepository.GetAsync(e => e.Id == command.Request.Id);
                _mapper.Map(command.Request, exercise);

                var updatedExercise = await _exerciseRepository.UpdateAsync(exercise);

                var response = _mapper.Map<UpdatedExerciseResponse>(updatedExercise);
                response.message = ExerciseMessages.ExerciseUpdated;
                return response;
            }
        }
    }
}
