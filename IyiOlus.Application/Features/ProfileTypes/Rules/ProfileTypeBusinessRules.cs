using IyiOlus.Application.Features.ProfileTypes.Constants;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PT = IyiOlus.Domain.Enums.ProfileTypes;

namespace IyiOlus.Application.Features.ProfileTypes.Rules
{
    public class ProfileTypeBusinessRules
    {
        private readonly IProfileTypeRepository _profileTypeRepository;

        public ProfileTypeBusinessRules(IProfileTypeRepository profileTypeRepository)
        {
            _profileTypeRepository = profileTypeRepository;
        }

        public async Task ProfileTypeNotFound(Guid profileTypeId)
        {
            var result = await _profileTypeRepository.AnyAsync(pt => pt.ProfileTypeId == profileTypeId);
            if (!result)
                throw new Exception(ProfileTypeMessages.ProfileTypeNotFound);
        }


        public async Task ProfileTypeCountCannotBeGraterThanThree(PT profileType)
        {
            var profileTypeCount = await _profileTypeRepository.GetCountAsync(pt => pt.Type == profileType);
            if (profileTypeCount > 3)
                throw new Exception(ProfileTypeMessages.ProfileTypeCount);
        }
    }
}
