using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Dtos.Responses
{
    public class CreatedQuestionResponse
    {
        public Guid QuestionId { get; set; }
        public string ProfileQuestion { get; set; } = default!;
        public QuestionTypes QuestionType { get; set; }
        //public Guid ProfileTypeId { get; set; }
        //public ProfileType ProfileType { get; set; } = default!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
