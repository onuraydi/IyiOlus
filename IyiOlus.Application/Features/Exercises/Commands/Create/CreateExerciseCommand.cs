using AutoMapper;
using IyiOlus.Application.Features.Exercises.Constants;
using IyiOlus.Application.Features.Exercises.Dtos.Requests;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
using IyiOlus.Application.Features.Exercises.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Commands.Create
{
    public class CreateExerciseCommand:IRequest<CreatedExerciseResponse>
    {
        public CreateExerciseRequest Request { get; set; } = default!;

        public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, CreatedExerciseResponse>
        {
            private readonly IExerciseRepository _exerciseRepository;
            private readonly IMapper _mapper;
            private readonly ExerciseBusinesssRules _exerciseBusinesssRules;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, IMapper mapper, ExerciseBusinesssRules exerciseBusinesssRules, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _exerciseRepository = exerciseRepository;
                _mapper = mapper;
                _exerciseBusinesssRules = exerciseBusinesssRules;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<CreatedExerciseResponse> Handle(CreateExerciseCommand command, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var exercise = _mapper.Map<Exercise>(command.Request);
                exercise.UserId = userId;
                var createdExercise = await _exerciseRepository.AddAsync(exercise);

                var response = _mapper.Map<CreatedExerciseResponse>(createdExercise);
                response.message = ExerciseMessages.ExerciseCreated;
                return response;
            }
        }
    }
}
