using AutoMapper;
using IyiOlus.Application.Features.Notifications.Dtos.Responses;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.Repositories.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Queries.GetListByUserId
{
    public class GetListByUserIdNotificationQuery:IRequest<Paginate<NotificationResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public class GetListByUserIdNotificationQueryHandler : IRequestHandler<GetListByUserIdNotificationQuery, Paginate<NotificationResponse>>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            private readonly IAuthenticatedUserRepository _authenticatedUserRepository;

            public GetListByUserIdNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper, IAuthenticatedUserRepository authenticatedUserRepository)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _authenticatedUserRepository = authenticatedUserRepository;
            }

            public async Task<Paginate<NotificationResponse>> Handle(GetListByUserIdNotificationQuery request, CancellationToken cancellationToken)
            {
                var userId = await _authenticatedUserRepository.GetAuthenticatedUserId();

                var notification = await _notificationRepository.GetListAsync(
                    index: request.PageIndex,
                    size: request.PageSize,
                    predicate: x => x.UserId == userId,
                    cancellationToken:cancellationToken
                    );

                var response = _mapper.Map<Paginate<NotificationResponse>>(notification);
                return response;
            }
        }
    }
}
