using AutoMapper;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
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

namespace IyiOlus.Application.Features.Exercises.Queries.GetListByUserId
{
    public class GetListByUserIdExerciseQuery:IRequest<Paginate<ExerciseResponse>>
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public class GetLİstByUserIdExerciseQueryHandler : IRequestHandler<GetListByUserIdExerciseQuery, Paginate<ExerciseResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IExerciseRepository _exerciseRepository;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public GetLİstByUserIdExerciseQueryHandler(IMapper mapper, IExerciseRepository exerciseRepository, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _mapper = mapper;
                _exerciseRepository = exerciseRepository;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<ExerciseResponse>> Handle(GetListByUserIdExerciseQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var exercise = await _exerciseRepository.GetListAsync(
                        index: request.pageIndex,
                        size: request.pageSize,
                        predicate: x => x.UserId == userId,
                        include: x => x.Include(y => y.User),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<ExerciseResponse>>(exercise);
                return response;
            }
        }
    }
}
