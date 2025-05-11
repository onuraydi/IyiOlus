using AutoMapper;
using IyiOlus.Application.Features.ProfileTypes.Constants;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Requests;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Features.ProfileTypes.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Commands.Create
{
    public class CreateProfileTypeCommand:IRequest<CreatedProfileTypeResponse>
    {
        public CreateProfileTypeRequest Request { get; set; } = default!;

        public class CreateProfileTypeCommandHandler : IRequestHandler<CreateProfileTypeCommand, CreatedProfileTypeResponse>
        {

            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProfileTypeBusinessRules _profileTypeBusinessRules;

            public CreateProfileTypeCommandHandler(IProfileTypeRepository profileTypeRepository, IMapper mapper, ProfileTypeBusinessRules profileTypeBusinessRules)
            {
                _profileTypeRepository = profileTypeRepository;
                _mapper = mapper;
                _profileTypeBusinessRules = profileTypeBusinessRules;
            }

            public async Task<CreatedProfileTypeResponse> Handle(CreateProfileTypeCommand command, CancellationToken cancellationToken)
            {
                await _profileTypeBusinessRules.ProfileTypeCountCannotBeGraterThanThree(command.Request.ProfileType);

                var profileType = _mapper.Map<ProfileType>(command.Request);
                var createdProfileType = await _profileTypeRepository.AddAsync(profileType);

                var response = _mapper.Map<CreatedProfileTypeResponse>(createdProfileType);
                response.Message = ProfileTypeMessages.ProfileTypeCreated;
                return response;
            }
        }
    }
}
