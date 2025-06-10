using IyiOlus.Application.Features.UserAccounts.Constants;
using IyiOlus.Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Rules
{
    public class UserAccountBusinessRules
    {
        private readonly IUserAccountInfoRepository _userAccountInfoRepository;

        public UserAccountBusinessRules(IUserAccountInfoRepository userAccountInfoRepository)
        {
            _userAccountInfoRepository = userAccountInfoRepository;
        }

        public async Task UserAccountNotFound(Guid userAccountId)
        {
            var result = await _userAccountInfoRepository.AnyAsync(ua => ua.Id == userAccountId);
            if (!result)
                throw new Exception(UserAccountMessages.UserAccountNotFound);
        }

        public void UserEmailIsNotValid(string mail)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (!Regex.IsMatch(mail, pattern))
                throw new Exception(UserAccountMessages.UserEmailNotValid);
        }

        public void UserPasswordIsNotValid(string password)
        {
            var result = password.Length >= 8 &&
               Regex.IsMatch(password, @"[A-Z]") &&
               Regex.IsMatch(password, @"[a-z]") &&
               Regex.IsMatch(password, @"[0-9]") &&
               Regex.IsMatch(password, @"[!@#$%^&*(),.?""{}|<>]");

            if (!result)
                throw new Exception(UserAccountMessages.UserPasswordNotValid);
        }
    }
}
