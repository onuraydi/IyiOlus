using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Constants
{
    public static class UserProfileMessages
    {
        public const string UserProfileNotFound = "User profile not found";
        public const string UserProfileCreated = "User profile created successfully";
        public const string UserProfileUpdated = "User profile updated successfully";
        public const string UserProfileDeleted = "User profile deleteed successfully";

        public const string UserProfileBlock = "A user can only profile once in the same day"; // userId ve Date uniq
        public const string UserProfileNotPossible = "Such a profile is not logically possible";  
    }
}
