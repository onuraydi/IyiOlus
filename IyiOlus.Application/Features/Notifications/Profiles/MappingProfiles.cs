using AutoMapper;
using IyiOlus.Application.Features.Notifications.Dtos.Requests;
using IyiOlus.Application.Features.Notifications.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Notifications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Notification, NotificationResponse>().ReverseMap();
            CreateMap<Notification, CreatedNotificationResponse>();
            CreateMap<Notification, UpdatedNotificationResponse>();

            CreateMap<CreateNotificationRequest, Notification>();
            CreateMap<UpdateNotificationRequest, Notification>();

            CreateMap<Paginate<Notification>, Paginate<NotificationResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
