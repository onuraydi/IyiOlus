using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Services.Repositories
{
    public interface IExerciseRepository:IAsyncRepository<Exercise,Guid>
    {
    }
}
