using AutoMapper;
using IyiOlus.Application.Features.Questions.Constants;
using IyiOlus.Application.Features.Questions.Dtos.Requests;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Features.Questions.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Commands.Update
{
    public class UpdateQuestionCommand:IRequest<UpdatedQuestionResponse>
    {
        public UpdateQuestionRequest Request { get; set; } = default!;

        public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, UpdatedQuestionResponse>
        {
            private readonly IQuestionRepository _questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public UpdateQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper, QuestionBusinessRules questionBusinessRules)
            {
                _questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<UpdatedQuestionResponse> Handle(UpdateQuestionCommand command, CancellationToken cancellationToken)
            {
                await _questionBusinessRules.QuestionNotFound(command.Request.QuestionId);

                var question = await _questionRepository.GetAsync(q => q.Id == command.Request.QuestionId);
                _mapper.Map(command.Request, question);

                var updatedQuestion = await _questionRepository.UpdateAsync(question);

                var response = _mapper.Map<UpdatedQuestionResponse>(updatedQuestion);
                response.Message = QuestionMessages.QuestionUpdated;
                return response;
            }
        }
    }
}
