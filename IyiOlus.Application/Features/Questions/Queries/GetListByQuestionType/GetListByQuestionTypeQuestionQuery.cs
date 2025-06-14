using AutoMapper;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Queries.GetListByQuestionType
{
    public class GetListByQuestionTypeQuestionQuery:IRequest<Paginate<QuestionResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public QuestionTypes QuestionType { get; set; }

        public class GetListQuestionTypeQuestionQueryHandler : IRequestHandler<GetListByQuestionTypeQuestionQuery, Paginate<QuestionResponse>>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;

            public GetListQuestionTypeQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<QuestionResponse>> Handle(GetListByQuestionTypeQuestionQuery request, CancellationToken cancellationToken)
            {
                var questions = await _questionRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        predicate: q => q.QuestionType == request.QuestionType,
                        //include: x => x.Include()
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<QuestionResponse>>(questions);
                return response;
            }
        }
    }
}
