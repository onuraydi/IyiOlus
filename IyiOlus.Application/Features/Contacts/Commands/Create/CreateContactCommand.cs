using AutoMapper;
using IyiOlus.Application.Features.Contacts.Constants;
using IyiOlus.Application.Features.Contacts.Dtos.Requests;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Application.Features.Contacts.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Commands.Create
{
    public class CreateContactCommand:IRequest<CreatedContactResponse>
    {
        // Burada Eposta gönderileceği için kullanıcı kodları yazıldıktan sonra tekrar dönüş yapılacak.
        public CreateContactRequest Request { get; set; } = default!;

        public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreatedContactResponse>
        {
            private readonly IContactRepository _contactRepository;
            private readonly IMapper _mapper;
            private readonly ContactBusinessRules _contactBusinessRules;
            private readonly UserManager<ApplicationUser> _userManager;

            public CreateContactCommandHandler(IContactRepository contactRepository, IMapper mapper, ContactBusinessRules contactBusinessRules, UserManager<ApplicationUser> userManager)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
                _contactBusinessRules = contactBusinessRules;
                _userManager = userManager;
            }

            public async Task<CreatedContactResponse> Handle(CreateContactCommand command, CancellationToken cancellationToken)
            {
                _contactBusinessRules.MessageCannotBeShorterThenTenChar(command.Request.Message);
                _contactBusinessRules.MessageCannotBeLongerThenThousandChar(command.Request.Message);

                _contactBusinessRules.SubjecCannotBeShorterThenThreeChar(command.Request.Subject);
                _contactBusinessRules.SubjectCannotBeLongerThenTwoHundredChar(command.Request.Subject);

                _contactBusinessRules.TheUserCannotSendEmptyOrSpamMessages(command.Request.Message);
                _contactBusinessRules.TheUserCannotSendEmptyOrSpamSubject(command.Request.Subject);

                await _contactBusinessRules.TheUserCannotSendExitFrequentMessages(command.Request.UserId);

                var user = await _userManager.FindByEmailAsync(ClaimTypes.NameIdentifier);

                var contact = _mapper.Map<Contact>(command.Request);
                contact.UserId = user.Id;
                var createdContact = await _contactRepository.AddAsync(contact);

                var response = _mapper.Map<CreatedContactResponse>(createdContact);
                response.Message = ContactMessages.ContactSended;
                return response;
            }
        }
    }
}
