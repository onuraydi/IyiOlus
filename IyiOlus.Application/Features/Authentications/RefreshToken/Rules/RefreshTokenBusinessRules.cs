using IyiOlus.Application.Features.Authentications.RefreshToken.Constants;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.RefreshToken.Rules
{
    public class RefreshTokenBusinessRules
    {
        public Task RefreshTokenShouldNotBeExpired(DateTime? ExpiryDate)
        {

            if (ExpiryDate < DateTime.Now)
                throw new Exception(RefreshTokenMessages.RefreshTokenShouldNotBeExpired);
            return Task.CompletedTask;
        }
    }
}
