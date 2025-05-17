using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Constants
{
    public static class UserAccountMessages
    {
        public const string UserAccountNotFound = "User account not found";
        public const string UserAccountCreated = "User account created successfully";
        public const string UserAccountUpdated = "User account updated successfully";
        public const string UserAccountDeleted = "User account deleted successfully";

        public const string UserEmailNotValid = "Your email is not valid.";
        public const string UserPasswordNotValid = "Password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.";
        public const string EmailNotValidation = "your e-mail could not be verified";
    }
}
