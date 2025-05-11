using AutoMapper;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Features.ProfileTypes.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Queries.GetById
{
    public class GetByIdProfileTypeQuery:IRequest<ProfileTypeResponse>
    {
        public Guid ProfileTypeId { get; set; }

        public class GetByIdProfileTypeQueryHandler : IRequestHandler<GetByIdProfileTypeQuery, ProfileTypeResponse>
        {
            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProfileTypeBusinessRules _profileTypeBusinessRules;

            public GetByIdProfileTypeQueryHandler(IProfileTypeRepository profileTypeRepository, IMapper mapper, ProfileTypeBusinessRules profileTypeBusinessRules)
            {
                _profileTypeRepository = profileTypeRepository;
                _mapper = mapper;
                _profileTypeBusinessRules = profileTypeBusinessRules;
            }

            public async Task<ProfileTypeResponse> Handle(GetByIdProfileTypeQuery request, CancellationToken cancellationToken)
            {
                await _profileTypeBusinessRules.ProfileTypeNotFound(request.ProfileTypeId);

                var profileType = await _profileTypeRepository.GetAsync(pt => pt.ProfileTypeId == request.ProfileTypeId);

                var response = _mapper.Map<ProfileTypeResponse>(profileType);
                return response;
            }
        }
    }
}
