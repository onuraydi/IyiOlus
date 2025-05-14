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
            CreateMap<UserResponse, User>();
            CreateMap<CreatedUserResponse, User>();
            CreateMap<UpdatedUserResponse, User>();
            CreateMap<DeletedUserResponse, User>();

            CreateMap<User, CreateUserRequest>();
            CreateMap<User, UpdateUserRequest>();

            CreateMap<Paginate<User>, Paginate<UserResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
