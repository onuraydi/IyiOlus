using AutoMapper;
using IyiOlus.Application.Features.Questions.Constants;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Application.Features.Questions.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Commands.Delete
{
    public class DeleteQuestionCommand:IRequest<DeletedQuestionResponse>
    {
        public Guid QuestionId { get; set; }

        public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, DeletedQuestionResponse>
        {
            private readonly IQuestionRepository __questionRepository;
            private readonly IMapper _mapper;
            private readonly QuestionBusinessRules _questionBusinessRules;

            public DeleteQuestionCommandHandler(IQuestionRepository questionRepository, IMapper mapper, QuestionBusinessRules questionBusinessRules)
            {
                __questionRepository = questionRepository;
                _mapper = mapper;
                _questionBusinessRules = questionBusinessRules;
            }

            public async Task<DeletedQuestionResponse> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
            {
                await _questionBusinessRules.QuestionNotFound(request.QuestionId);

                var question = await __questionRepository.GetAsync(q => q.Id == request.QuestionId);
                if(question!= null)
                    await __questionRepository.DeleteAsync(question);

                return new DeletedQuestionResponse
                {
                    Id = request.QuestionId,
                    Message = QuestionMessages.QuestionDeleted,
                };
            }
        }
    }
}
