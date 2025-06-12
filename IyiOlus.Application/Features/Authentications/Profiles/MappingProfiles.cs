using AutoMapper;
using IyiOlus.Application.Features.Authentications.Dtos.Requests;
using IyiOlus.Application.Features.Authentications.Dtos.Responses;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Authentications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ApplicationUser, RegisterResponse>().ReverseMap();
            CreateMap<RegisterRequest,ApplicationUser>().ReverseMap();
        }
    }
}
