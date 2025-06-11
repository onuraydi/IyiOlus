using AutoMapper;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Features.Questions.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Queries.GetList
{
    public class GetListQuestionQuery:IRequest<Paginate<QuestionResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListQuestionQueryHandler : IRequestHandler<GetListQuestionQuery, Paginate<QuestionResponse>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;

            public GetListQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<QuestionResponse>> Handle(GetListQuestionQuery request, CancellationToken cancellationToken)
            {
                var questions = await _questionRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        include: x => x.Include(y => y.ProfileType),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<QuestionResponse>>(questions);
                return response;
            }
        }
    }
}
