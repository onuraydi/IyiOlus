using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Dtos.Responses
{
    public class DeletedExerciseResponse
    {
        public Guid Id { get; set; }
        public string message { get; set; } = default!;
    }
}
