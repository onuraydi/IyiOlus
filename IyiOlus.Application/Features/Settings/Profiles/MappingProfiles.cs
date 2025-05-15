using AutoMapper;
using IyiOlus.Application.Features.Settings.Dtos.Requests;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Setting, SettingResponse>();
            CreateMap<Setting, CreatedSettingResponse>();
            CreateMap<Setting, UpdatedSettingResponse>();
            CreateMap<Setting, DeletedSettingResponse>();

            CreateMap<CreateSettingRequest, Setting>();
            CreateMap<UpdatedSettingResponse, Setting>();

            CreateMap<Paginate<Setting>, Paginate<SettingResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        }
    }
}
