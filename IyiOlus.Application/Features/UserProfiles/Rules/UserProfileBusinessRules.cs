using IyiOlus.Application.Features.UserProfiles.Constants;
using IyiOlus.Application.Services.Repositories;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Rules
{
    public class UserProfileBusinessRules
    {
        private readonly IUserProfileRepository _userProfileRepository;
        public UserProfileBusinessRules(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task UserProfileNotFound(Guid userProfileId)
        {
            var result = await _userProfileRepository.AnyAsync(up => up.Id == userProfileId);
            if (!result)
                throw new Exception(UserProfileMessages.UserProfileNotFound);
        }

        public async Task UserProfileBlock(Guid userId, DateTime profileTestDate)
        {
            var result = await _userProfileRepository.AnyAsync(up => up.UserId == userId && up.ProfileTestDate.Date == profileTestDate.Date);
            if (result)
                throw new Exception(UserProfileMessages.UserProfileBlock);
        }

        public async Task UserProfileNotPossible()
        {
            var result = await _userProfileRepository.AnyAsync(up => up.Profile == Profile.Yok);
            if (result)
                throw new Exception(UserProfileMessages.UserProfileNotPossible);
        }
    }
}
