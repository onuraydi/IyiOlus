using AutoMapper;
using IyiOlus.Application.Features.DailyMoods.Dtos.Requests;
using IyiOlus.Application.Features.DailyMoods.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.DailyMoods.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<DailyMood, DailyMoodResponse>();
            CreateMap<DailyMood, CreatedDailyMoodResponse>();

            CreateMap<CreateDailyMoodRequest, DailyMood>();

            CreateMap<Paginate<DailyMood>, Paginate<DailyMoodResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
