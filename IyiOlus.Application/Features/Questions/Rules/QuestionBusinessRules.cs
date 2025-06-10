using IyiOlus.Application.Features.Questions.Constants;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Rules
{
    public class QuestionBusinessRules
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionBusinessRules(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task QuestionNotFound(Guid questionId)
        {
            var result = await _questionRepository.AnyAsync(q => q.Id == questionId);
            if (!result)
                throw new Exception(QuestionMessages.QuestionNotFound);
        }

        public async Task QuestionCountCannotBeGraterThanTwenty(string profileQuestion)
        {
            var questionCount = await _questionRepository.GetCountAsync(q => q.ProfileQuestion == profileQuestion);
            if (questionCount > 20)
                throw new Exception(QuestionMessages.QuestionCount);
        }
    }
}
