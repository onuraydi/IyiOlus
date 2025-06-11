using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Dtos.Responses
{
    public class DeletedQuestionResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; } = default!;
    }
}
