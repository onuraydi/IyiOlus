using AutoMapper;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Application.Features.Contacts.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Queries.GetById
{
    public class GetByIdContactQuery:IRequest<ContactResponse>
    {
        public Guid id { get; set; }

        public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, ContactResponse>
        {
            private readonly IContactRepository _contactRepository;
            private readonly IMapper _mapper;
            private readonly ContactBusinessRules _contactBusinessRules;

            public GetByIdContactQueryHandler(IContactRepository contactRepository, IMapper mapper, ContactBusinessRules contactBusinessRules)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
                _contactBusinessRules = contactBusinessRules;
            }

            public async Task<ContactResponse> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
            {
                await _contactBusinessRules.MessageNotFound(request.id);

                var contact = await _contactRepository.GetAsync(c => c.Id == request.id);
                var response = _mapper.Map<ContactResponse>(contact);
                return response;
            }
        }
    }
}
