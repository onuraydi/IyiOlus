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

namespace IyiOlus.Application.Features.Contacts.Queries.GetListByUserId
{
    public class GetListByUserIdQuery:IRequest<Paginate<ContactResponse>>
    {
        public Guid UserId { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        public class GetListByUserIdQueryHandler : IRequestHandler<GetListByUserIdQuery, Paginate<ContactResponse>>
        {
            private readonly IContactRepository _contactRepository;
            private readonly IMapper _mapper;

            public GetListByUserIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
            {
                _contactRepository = contactRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<ContactResponse>> Handle(GetListByUserIdQuery request, CancellationToken cancellationToken)
            {
                var contacts = await _contactRepository.GetListAsync(
                        predicate: u => u.UserId == request.UserId,
                        index: request.PageIndex,
                        size: request.PageSize,
                        //include: c => c.Include(x => x.)
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<Paginate<ContactResponse>>(contacts);
                return response;
            }
        }
    }
}
