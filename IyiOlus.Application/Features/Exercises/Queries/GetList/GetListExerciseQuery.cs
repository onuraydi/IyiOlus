using AutoMapper;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Queries.GetList
{
    public class GetListExerciseQuery:IRequest<Paginate<ExerciseResponse>>
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }

        public class GetListExerciseQueryHandler : IRequestHandler<GetListExerciseQuery, Paginate<ExerciseResponse>>
        {
            private readonly IExerciseRepository _exerciseRepository;
            private readonly IMapper _mapper;

            public GetListExerciseQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
            {
                _exerciseRepository = exerciseRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<ExerciseResponse>> Handle(GetListExerciseQuery request, CancellationToken cancellationToken)
            {
                var exercise = await _exerciseRepository.GetListAsync(
                        index: request.pageIndex,
                        size: request.pageSize,
                        include: x => x.Include(y => y.User),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<ExerciseResponse>>(exercise);
                return response;
            }
        }
    }
}
