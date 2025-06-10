using AutoMapper;
using IyiOlus.Application.Features.Users.Dtos.Requests;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.UserAccountResponse, opt => opt.MapFrom(src => src.UserAccountInfo));
            CreateMap<CreatedUserResponse, User>().ReverseMap();
            CreateMap<UpdatedUserResponse, User>().ReverseMap();
            CreateMap<DeletedUserResponse, User>().ReverseMap();

            CreateMap<User, CreateUserRequest>().ReverseMap();
            CreateMap<User, UpdateUserRequest>().ReverseMap();

            CreateMap<Paginate<User>, Paginate<UserResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
