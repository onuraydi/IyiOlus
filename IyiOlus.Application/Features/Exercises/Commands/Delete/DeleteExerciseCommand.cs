using AutoMapper;
using IyiOlus.Application.Features.Exercises.Constants;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
using IyiOlus.Application.Features.Exercises.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Commands.Delete
{
    public class DeleteExerciseCommand:IRequest<DeletedExerciseResponse>
    {
        public Guid ExerciseId { get; set; }

        public class DeleteExerciseCommandHandler : IRequestHandler<DeleteExerciseCommand, DeletedExerciseResponse>
        {
            private readonly IExerciseRepository _exerciseRepository;
            private readonly ExerciseBusinesssRules _exerciseBusinesssRules;

            public DeleteExerciseCommandHandler(IExerciseRepository exerciseRepository, ExerciseBusinesssRules exerciseBusinesssRules)
            {
                _exerciseRepository = exerciseRepository;
                _exerciseBusinesssRules = exerciseBusinesssRules;
            }

            public async Task<DeletedExerciseResponse> Handle(DeleteExerciseCommand command, CancellationToken cancellationToken)
            {
                await _exerciseBusinesssRules.ExerciseNotFound(command.ExerciseId);

                var exercise = await _exerciseRepository.GetAsync(e => e.Id == command.ExerciseId);
                if (exercise != null)
                    await _exerciseRepository.DeleteAsync(exercise);

                return new DeletedExerciseResponse
                {
                    Id = command.ExerciseId,
                    message = ExerciseMessages.ExerciseDeleted
                };
            }
        }
    }
}
