using AutoMapper;
using IyiOlus.Application.Features.ProfileTypes.Constants;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Requests;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Features.ProfileTypes.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Commands.Update
{
    public class UpdateProfileTypeCommand:IRequest<UpdatedProfileTypeResponse>
    {
        public UpdateProfileTypeRequest Request { get; set; } = default!;

        public class UpdateProfileTypeCommandHandler : IRequestHandler<UpdateProfileTypeCommand, UpdatedProfileTypeResponse>
        {
            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProfileTypeBusinessRules _profileTypeBusinessRules;

            public UpdateProfileTypeCommandHandler(IProfileTypeRepository profileTypeRepository, IMapper mapper, ProfileTypeBusinessRules profileTypeBusinessRules)
            {
                _profileTypeRepository = profileTypeRepository;
                _mapper = mapper;
                _profileTypeBusinessRules = profileTypeBusinessRules;
            }

            public async Task<UpdatedProfileTypeResponse> Handle(UpdateProfileTypeCommand command, CancellationToken cancellationToken)
            {
                await _profileTypeBusinessRules.ProfileTypeNotFound(command.Request.ProfileTypeId);

                var profileType = await _profileTypeRepository.GetAsync(pt => pt.ProfileTypeId == command.Request.ProfileTypeId);
                _mapper.Map(command.Request, profileType);

                var updatedProfileType = await _profileTypeRepository.UpdateAsync(profileType);
                var response = _mapper.Map<UpdatedProfileTypeResponse>(updatedProfileType);
                response.Message = ProfileTypeMessages.ProfileTypeUpdated;
                return response;
            }
        }
    }
}
