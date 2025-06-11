using AutoMapper;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Requests;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IyiOlus.Application.Features.ProfileTypes.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProfileType, ProfileTypeResponse>();
            CreateMap<ProfileType, CreatedProfileTypeResponse>();
            CreateMap<ProfileType, UpdatedProfileTypeResponse>();
            CreateMap<ProfileType, DeletedProfileTypeResponse>();
                
            CreateMap<CreateProfileTypeRequest, ProfileType>();
            CreateMap<UpdateProfileTypeRequest, ProfileType>();

            CreateMap<Paginate<ProfileType>, Paginate<ProfileTypeResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
