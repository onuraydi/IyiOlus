using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Dtos.Requests
{
    public class CreateQuestionRequest
    {
        public string ProfileQuestion { get; set; } = default!;
        public QuestionTypes QuestionType { get; set; }
        public Guid ProfileTypeId { get; set; }
    }
}
