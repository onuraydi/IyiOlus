using IyiOlus.Application.Features.Exercises.Constants;
using IyiOlus.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Rules
{
    public class ExerciseBusinesssRules
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseBusinesssRules(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public async Task ExerciseNotFound(Guid exerciseId)
        {
            var result = await _exerciseRepository.AnyAsync(x => x.Id == exerciseId);
            if (!result)
                throw new Exception(ExerciseMessages.ExerciseNotFound);
        }

        public void ProgressMaxAndMinValueError(int progress)
        {
            if (progress < 0 || progress > 100)
                throw new Exception(ExerciseMessages.ProgressMinAndMaxValueError);
        }
    }
}
