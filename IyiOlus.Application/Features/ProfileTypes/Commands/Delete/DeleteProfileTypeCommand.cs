using AutoMapper;
using IyiOlus.Application.Features.Contacts.Dtos.Responses;
using IyiOlus.Application.Features.ProfileTypes.Constants;
using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Features.ProfileTypes.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.ProfileTypes.Commands.Delete
{
    public class DeleteProfileTypeCommand:IRequest<DeletedProfileTypeResponse>
    {
        public Guid ProfileTypeId { get; set; }

        public class DeleteProfileTypeCommandHandler : IRequestHandler<DeleteProfileTypeCommand, DeletedProfileTypeResponse>
        {

            private readonly IProfileTypeRepository _profileTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProfileTypeBusinessRules _profileTypeBusinessRules;

            public DeleteProfileTypeCommandHandler(IProfileTypeRepository profileTypeRepository, IMapper mapper, ProfileTypeBusinessRules profileTypeBusinessRules)
            {
                _profileTypeRepository = profileTypeRepository;
                _mapper = mapper;
                _profileTypeBusinessRules = profileTypeBusinessRules;
            }

            public async Task<DeletedProfileTypeResponse> Handle(DeleteProfileTypeCommand request, CancellationToken cancellationToken)
            {
                await _profileTypeBusinessRules.ProfileTypeNotFound(request.ProfileTypeId);

                var profileType = await _profileTypeRepository.GetAsync(pt => pt.ProfileTypeId == request.ProfileTypeId);

                if (profileType != null)
                    await _profileTypeRepository.DeleteAsync(profileType);

                return new DeletedProfileTypeResponse
                {
                    ProfileTypeId = request.ProfileTypeId,
                    Message = ProfileTypeMessages.ProfileTypeDeleted
                };
            }
        }
    }
}
