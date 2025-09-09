using AutoMapper;
using IyiOlus.Application.Features.Statistics.UserProfilesStatistics.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Statistics.UserProfilesStatistics.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, UserProfilesStatisticResponse>();
            CreateMap<Paginate<UserProfile>, Paginate<UserProfilesStatisticResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
