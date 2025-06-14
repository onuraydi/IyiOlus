using AutoMapper;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Queries.GetList
{
    public class GetListContactQuery:IRequest<Paginate<ContactResponse>>
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, Paginate<ContactResponse>>
        {
            private readonly IContactRepository _contactRepository;
            private readonly IMapper _mapper;

            public GetListContactQueryHandler(IContactRepository contactRepository, IMapper mapper)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<ContactResponse>> Handle(GetListContactQuery request, CancellationToken cancellationToken)
            {
                var contacts = await _contactRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        include: c => c.Include(x => x.User).ThenInclude(y => y.ApplicationUser),
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<ContactResponse>>(contacts);
                return response;
            }
        }
    }
}
