using IyiOlus.Application.Features.Authentications.Login.Constants;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Login.Rules
{
    public class LoginBusinessRules
    {
        public Task EmailOrPasswordShouldNotBeInvalid(ApplicationUser user, bool checkPassword)
        {
            if (user is null || !checkPassword)
                throw new Exception(LoginMessages.EmailOrPasswordShouldNotBeInvalid);

            return Task.CompletedTask;
        }
    }
}
