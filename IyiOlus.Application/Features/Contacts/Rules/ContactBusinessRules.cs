using IyiOlus.Application.Features.Contacts.Constants;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Rules
{
    public class ContactBusinessRules
    {
        private readonly IContactRepository _contactRepository;

        public ContactBusinessRules(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task MessageNotFound(Guid contactId)
        {
            var result = await _contactRepository.AnyAsync(c => c.Id == contactId);
            if (!result)
            {
                throw new Exception(ContactMessages.ContactNotFound);
            }
        }
        public void MessageCannotBeShorterThenTenChar(string message)
        {
            if(message.Count() < 10)
            {
                throw new Exception(ContactMessages.MessageShort);
            }
        }

        public void MessageCannotBeLongerThenThousandChar(string message)
        {
            if(message.Count() > 1000)
            {
                throw new Exception(ContactMessages.MessageLong);
            }
        }

        public void SubjecCannotBeShorterThenThreeChar(string subject)
        {
            if(subject.Count() < 3)
            {
                throw new Exception(ContactMessages.SubjectShort);
            }
        }

        public void SubjectCannotBeLongerThenTwoHundredChar(string subject)
        {
            if(subject.Count() > 200)
            {
                throw new Exception(ContactMessages.SubjectLong);
            }
        }

        public async Task TheUserCannotSendExitFrequentMessages(Guid user)
        {
            var now = DateTime.UtcNow;
            var tenMinutesAgo = now.AddMinutes(-10);
            var recentMessagesCount = await _contactRepository
                .GetCountAsync(c => c.UserId == user && c.CreatedDate >= tenMinutesAgo);

            if (recentMessagesCount >= 2)
            {
                throw new Exception(ContactMessages.MessageTooOften);
            }
        }

        public void TheUserCannotSendEmptyOrSpamMessages(string message)
        {
            var cleanedMessage = message.Trim();
            if(string.IsNullOrWhiteSpace(cleanedMessage) || cleanedMessage.All(c => !char.IsLetterOrDigit(c)))
            {
                throw new Exception(ContactMessages.MessageSpam);
            }
        }

        public void TheUserCannotSendEmptyOrSpamSubject(string subject)
        {
            var cleanedSubject = subject.Trim();
            if(string.IsNullOrWhiteSpace(cleanedSubject) || cleanedSubject.All(c => !char.IsLetterOrDigit(c)))
            {
                throw new Exception(ContactMessages.SubjectSpam);
            }
        }
    }
}
