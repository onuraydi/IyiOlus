using AutoMapper;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Features.Questions.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Queries.GetById
{
    public class GetByIdQuestionQuery:IRequest<QuestionResponse>
    {
        public Guid QuestionId { get; set; }

        public class GetByIdQuestionQueryHandler : IRequestHandler<GetByIdQuestionQuery, QuestionResponse>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public GetByIdQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper, QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<QuestionResponse> Handle(GetByIdQuestionQuery request, CancellationToken cancellationToken)
            {
                await _questionBusinessRules.QuestionNotFound(request.QuestionId);

                var question = await _questionRepository.GetAsync(
                    predicate: q => q.Id == request.QuestionId,
                    include: x => x.Include(y => y.ProfileType),
                    cancellationToken: cancellationToken);

                var response = _mapper.Map<QuestionResponse>(question);
                return response;
            }
        }
    }
}
