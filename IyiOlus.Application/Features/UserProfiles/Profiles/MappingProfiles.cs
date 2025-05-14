using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Dtos.Requests;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<UserProfile, CreatedUserProfileResponse>();
            CreateMap<UserProfile, UpdatedUserProfileResponse>();
            CreateMap<UserProfile, DeletedUserProfileResponse>();

            CreateMap<CreateUserProfileRequest, UserProfile>();
            CreateMap<UpdateUserProfileRequest, UserProfile>();

            CreateMap<Paginate<UserProfile>, Paginate<UserProfileResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            
        }
    }
}
