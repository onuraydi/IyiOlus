using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Entities;
using IyiOlus.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Persistence.Repositories
{
    public class ExerciseRepository : EfRepositoryBase<Exercise, Guid, BaseDbContext>, IExerciseRepository
    {
        public ExerciseRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
