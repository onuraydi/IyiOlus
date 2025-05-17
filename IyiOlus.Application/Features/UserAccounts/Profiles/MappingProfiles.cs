using AutoMapper;
using IyiOlus.Application.Features.UserAccounts.Dtos.Requests;
using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserAccountInfo, UserAccountResponse>();
            CreateMap<UserAccountInfo, CreatedUserAccountResponse>();
            CreateMap<UserAccountInfo, UpdatedUserAccountResponse>();
            CreateMap<UserAccountInfo, DeletedUserAccountResponse>();

            CreateMap<CreateUserAccountRequest, UserAccountInfo>();
            CreateMap<UpdateUserAccountRequest, UserAccountInfo>();

            CreateMap<Paginate<UserAccountInfo>, Paginate<UserAccountResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
