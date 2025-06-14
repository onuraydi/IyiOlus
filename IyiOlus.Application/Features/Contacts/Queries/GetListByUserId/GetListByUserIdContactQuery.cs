using AutoMapper;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Queries.GetListByUserId
{
    public class GetListByUserIdContactQuery:IRequest<Paginate<ContactResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public class GetListByUserIdContactQueryHandler : IRequestHandler<GetListByUserIdContactQuery, Paginate<ContactResponse>>
        {
            private readonly IContactRepository _contactRepository;
            private readonly IMapper _mapper;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;
            public GetListByUserIdContactQueryHandler(IContactRepository contactRepository, IMapper mapper, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<ContactResponse>> Handle(GetListByUserIdContactQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var contacts = await _contactRepository.GetListAsync(
                        predicate: u => u.UserId == userId,
                        index: request.PageIndex,
                        size: request.PageSize,
                        include: c => c.Include(x => x.User),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<ContactResponse>>(contacts);
                return response;
            }
        }
    }
}
