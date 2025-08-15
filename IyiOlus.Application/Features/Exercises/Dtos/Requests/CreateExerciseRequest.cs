using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Dtos.Requests
{
    public class CreateExerciseRequest
    {
        public string Name { get; set; } = default!;
        public string Detail { get; set; } = default!;
        public int Progress { get; set; }
    }
}
