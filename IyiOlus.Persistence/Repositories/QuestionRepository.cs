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
    public class QuestionRepository : EfRepositoryBase<Question, Guid, BaseDbContext>, IQuestionRepository
    {
        public QuestionRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
