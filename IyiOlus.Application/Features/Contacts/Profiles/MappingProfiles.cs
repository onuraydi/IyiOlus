using AutoMapper;
using IyiOlus.Application.Features.Contacts.Dtos.Requests;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Contacts.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Contact, ContactResponse>()
                .ForMember(dest => dest.UserResponse, opt => opt.MapFrom(src => src.User));
            CreateMap<Contact, CreatedContactResponse>()
                .ForMember(dest => dest.CreatedMessage, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.UserResponse, opt => opt.MapFrom(src => src.User));
            CreateMap<Contact, DeletedContactResponse>();

            CreateMap<CreateContactRequest, Contact>();

            CreateMap<Paginate<Contact>, Paginate<ContactResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
