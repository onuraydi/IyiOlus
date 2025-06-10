using IyiOlus.Application.Features.Contacts.Constants;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Application.Features.Contacts.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Commands.Delete
{
    public class DeleteContactCommand:IRequest<DeletedContactResponse>
    {
        public Guid id { get; set; }

        public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, DeletedContactResponse>
        {
            private readonly IContactRepository _contactRepository;

            public DeleteContactCommandHandler(IContactRepository contactRepository)
            {
                _contactRepository = contactRepository;
            }

            public async Task<DeletedContactResponse> Handle(DeleteContactCommand command, CancellationToken cancellationToken)
            {
                var contact = await _contactRepository.GetAsync(c => c.Id == command.id);
                
                if(contact != null)
                    await _contactRepository.DeleteAsync(contact);

                return new DeletedContactResponse
                {
                    ContactId = command.id,
                    Message = ContactMessages.ContactDeleted,
                };
            }
        }
    }
}
