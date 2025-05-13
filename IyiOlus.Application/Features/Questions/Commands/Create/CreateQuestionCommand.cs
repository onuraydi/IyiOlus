using AutoMapper;
using IyiOlus.Application.Features.Questions.Constants;
using IyiOlus.Application.Features.Questions.Dtos.Requests;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Features.Questions.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Commands.Create
{
    public class CreateQuestionCommand:IRequest<CreatedQuestionResponse>
    {
        public CreateQuestionRequest Request { get; set; } = default!;

        public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreatedQuestionResponse>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public CreateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper, QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<CreatedQuestionResponse> Handle(CreateQuestionCommand command, CancellationToken cancellationToken)
            {
                await _questionBusinessRules.QuestionCountCannotBeGraterThanTwenty(command.Request.ProfileQuestion);

                var question = _mapper.Map<Question>(command.Request);
                var createdQuestion = await _questionRepository.AddAsync(question);

                var response = _mapper.Map<CreatedQuestionResponse>(createdQuestion);
                response.Message = QuestionMessages.QuestionCreated;
                return response;
            }
        }
    }
}
