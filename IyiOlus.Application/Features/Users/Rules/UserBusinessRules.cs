using IyiOlus.Application.Features.Users.Constants;
using IyiOlus.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserNotFound(Guid userId)
        {
            var result = await _userRepository.AnyAsync(u => u.Id == userId);

            if (!result)
                throw new Exception(UserMessages.UserNotFound);
        }

        public void NameShort(string name)
        {
            if (name.Count() < 3)
                throw new Exception(UserMessages.nameShort);
        }

        public void NameLong(string name)
        {
            if (name.Count() > 35)
                throw new Exception(UserMessages.nameLong);
        }

        public void SurnameShort(string surname)
        {
            if (surname.Count() < 2)
                throw new Exception(UserMessages.surnameShort);
        }

        public void SurnameLong(string surname)
        {
            if (surname.Count() > 35)
                throw new Exception(UserMessages.surnameLong);
        }
    }
}
