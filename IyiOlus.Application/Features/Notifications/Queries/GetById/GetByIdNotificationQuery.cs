using AutoMapper;
using IyiOlus.Application.Features.Notifications.Dtos.Responses;
using IyiOlus.Application.Features.Notifications.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Queries.GetById
{
    public class GetByIdNotificationQuery:IRequest<NotificationResponse>
    {
        public Guid NotificationId { get; set; }
        public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQuery, NotificationResponse>
        {
            private readonly INotificationRepository _notificationRepository;
            private readonly IMapper _mapper;
            private readonly NotificationBusinessRules _notificationBusinessRules;

            public GetByIdNotificationQueryHandler(INotificationRepository notificationRepository, IMapper mapper, NotificationBusinessRules notificationBusinessRules)
            {
                _notificationRepository = notificationRepository;
                _mapper = mapper;
                _notificationBusinessRules = notificationBusinessRules;
            }

            public async Task<NotificationResponse> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
            {
                await _notificationBusinessRules.NotificationNotFound(request.NotificationId);

                var notification = await _notificationRepository.GetAsync(
                        predicate: x => x.Id == request.NotificationId,
                        cancellationToken: cancellationToken
                    );

                var response = _mapper.Map<NotificationResponse>(notification);
                return response;
            }
        }
    }
}
