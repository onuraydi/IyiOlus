using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications
{
    public class AuthenticatedUserManager : IAuthenticatedUserRepository
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedUserManager(IUserRepository userRepository, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> GetAuthenticatedUserId()
        {
            var email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            var appUser = await _userManager.FindByEmailAsync(email);
            var user = await _userRepository.GetAsync(
                predicate: u => u.ApplicationUserId == appUser.Id,
                cancellationToken: CancellationToken.None
                );
            return user.Id;
        }
    }
}
