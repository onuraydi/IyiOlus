using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Constants
{
    public static class UserMessages
    {
        public const string UserNotFound = "User not found";
        public const string UserCreated = "User created successfully";
        public const string UserUpdated = "User updated successfully";
        public const string userDeleted = "User deleted successfully";

        public const string nameShort = "Name cannot be shorter than 3 characters";
        public const string nameLong = "Name cannot be longer than 35 characters";
        public const string surnameShort = "Surname cannot be longer than 2 characters";
        public const string surnameLong = "Surname cannot be longer than 35 characters";
    }
}
