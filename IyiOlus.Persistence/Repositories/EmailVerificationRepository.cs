using IyiOlus.Application.Services.Repositories.AuthRepositories;
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
    class EmailVerificationRepository : EfRepositoryBase<EmailVerification, Guid, BaseDbContext>, IEmailVerificationRepository
    {
        public EmailVerificationRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
