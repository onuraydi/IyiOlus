using AutoMapper;
using IyiOlus.Application.Features.Exercises.Dtos.Requests;
using IyiOlus.Application.Features.Exercises.Dtos.Responses;
using IyiOlus.Core.Repositories.Pagination;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Exercises.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Exercise, ExerciseResponse>();
            CreateMap<Exercise, CreatedExerciseResponse>();
            CreateMap<Exercise, UpdatedExerciseResponse>();
            CreateMap<Exercise, DeletedExerciseResponse>();

            CreateMap<CreateExerciseRequest, Exercise>();
            CreateMap<UpdateExerciseRequest, Exercise>();

            CreateMap<Paginate<Exercise>, Paginate<ExerciseResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
