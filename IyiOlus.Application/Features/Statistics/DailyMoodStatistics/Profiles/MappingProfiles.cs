using AutoMapper;
using IyiOlus.Application.Features.Statistics.DailyMoodStatistics.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Statistics.DailyMoodStatistics.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DailyMood, DailyMoodStatisticResponse>();

            CreateMap<Paginate<DailyMood>, Paginate<DailyMoodStatisticResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
