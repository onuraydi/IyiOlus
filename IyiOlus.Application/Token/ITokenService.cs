using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.Repositories.Token
{
    public interface ITokenService
    {
        Task<JwtSecurityToken> CreateTokenAsync(
            ApplicationUser user,
            IList<string> roles,
            CancellationToken cancellationToken = default);

        string GenerateRefreshToken();

        ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
    }

}
