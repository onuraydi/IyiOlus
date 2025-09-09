using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Dtos.Responses
{
    public class ExerciseResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Detail { get; set; } = default!;
        public int Progress { get; set; }
        //public virtual User User { get; set; } = default!;
    }
}
