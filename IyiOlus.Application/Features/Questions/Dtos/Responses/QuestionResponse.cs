using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Dtos.Responses
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }
        public string ProfileQuestion { get; set; } = default!;
        public QuestionTypes QuestionType { get; set; }
        public virtual ProfileTypeResponse ProfileTypeResponse { get; set; } = default!;
        public Guid ProfileTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
