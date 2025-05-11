using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Constants
{
    public static class ContactMessages
    {
        public const string ContactNotFound = "Message not found";
        
        public const string MessageShort = "Message cannot be shorter than 10 characters";
        public const string SubjectShort = "Subject cannot be shorter than 3 characters";
        public const string MessageLong = "Message cannot be longer than 1000 characters";
        public const string SubjectLong = "Subject cannot be longer than 200 characters";
        
        public const string ContactSended = "Message sended successfully";
        public const string ContactDeleted = "Message Deleted successfully";


        public const string MessageTooOften = "you are sending messages too often please try again later";
        public const string MessageSpam = "You cannot send empty or spam messages";
        public const string SubjectSpam = "You cannot send empty or spam Subject";
    }
}
