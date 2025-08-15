using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Dtos.Requests;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;

namespace IyiOlus.Application.Features.UserProfiles.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserProfile, UserProfileResponse>()
                .ForMember(dest => dest.UserResponse, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.ProfileTypeResponse, opt => opt.MapFrom(src => src.ProfileType));
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
