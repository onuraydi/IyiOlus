using IyiOlus.Application.Features.Authentications.Register.Constants;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Register.Rules
{
    public class AuthBusinessRules
    {
        public Task UserShouldNotBeExist(ApplicationUser user)
        {
            if (user is not null)
                throw new Exception(AuthenticationMessages.UserShouldNotBeExist);
            return Task.CompletedTask;
        }
    }
}
