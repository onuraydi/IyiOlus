using AutoMapper;
using IyiOlus.Application.Features.Settings.Constants;
using IyiOlus.Application.Features.Settings.Dtos.Responses;
using IyiOlus.Application.Features.Settings.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Commands.Delete
{
    public class DeleteSettingCommand:IRequest<DeletedSettingResponse>
    {
        public Guid SettingId { get; set; }
        public class DeleteSettingCommandHandler : IRequestHandler<DeleteSettingCommand, DeletedSettingResponse>
        {
            private readonly ISettingRepository _settingRepository;
            private readonly SettingBusinessRules _settingBusinessRules;

            public DeleteSettingCommandHandler(ISettingRepository settingRepository, SettingBusinessRules settingBusinessRules)
            {
                _settingRepository = settingRepository;
                _settingBusinessRules = settingBusinessRules;
            }

            public async Task<DeletedSettingResponse> Handle(DeleteSettingCommand request, CancellationToken cancellationToken)
            {
                await _settingBusinessRules.SettingNotFound(request.SettingId);
                var setting = await _settingRepository.GetAsync(s => s.Id == request.SettingId);

                if(setting != null)
                    await _settingRepository.DeleteAsync(setting);

                return new DeletedSettingResponse
                {
                    SettingId = request.SettingId,
                    Message = SettingMessages.SettingDeleted,
                };


            }
        }
    }
}
