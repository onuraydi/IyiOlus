using IyiOlus.Application.Features.Authentications.Revoke.Constants;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Revoke.Rules
{
    public class RevokeBusinessRules
    {
        public Task EmailAddressShouldBeValid(ApplicationUser user)
        {
            if (user is null)
                throw new Exception(RevokeMessages.EmailAddressShouldBeValid);
            return Task.CompletedTask;
        }
    }
}
