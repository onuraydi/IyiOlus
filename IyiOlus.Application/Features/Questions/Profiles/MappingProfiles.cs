using AutoMapper;
using IyiOlus.Application.Features.Questions.Dtos.Requests;
using IyiOlus.Application.Features.Questions.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Questions.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Question, QuestionResponse>()
                .ForMember(dest => dest.ProfileTypeResponse, opt => opt.MapFrom(src => src.ProfileType));

            CreateMap<Question, CreatedQuestionResponse>()
                .ForMember(dest => dest.ProfileTypeResponse, opt => opt.MapFrom(src => src.ProfileType));
            CreateMap<Question, DeletedQuestionResponse>();

            CreateMap<Question, UpdatedQuestionResponse>()
                .ForMember(dest => dest.ProfileTypeResponse, opt => opt.MapFrom(src => src.ProfileType));

            CreateMap<CreateQuestionRequest, Question>();
            CreateMap<UpdateQuestionRequest, Question>();

            CreateMap<Paginate<Question>, Paginate<QuestionResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
