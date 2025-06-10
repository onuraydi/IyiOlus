using AutoMapper;
using IyiOlus.Application.Features.UserAccounts.Constants;
using IyiOlus.Application.Features.UserAccounts.Dtos.Requests;
using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Application.Features.UserAccounts.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Commands.Update
{
    public class UpdateUserAccountCommand:IRequest<UpdatedUserAccountResponse>
    {
        public UpdateUserAccountRequest Request { get; set; } = default!;

        public class UpdateUserAccountCommandHandler : IRequestHandler<UpdateUserAccountCommand, UpdatedUserAccountResponse>
        {
            private readonly IUserAccountInfoRepository _userAccountInfoRepository;
            private readonly IMapper _mapper;
            private readonly UserAccountBusinessRules _userAccountBusinessRules;

            public UpdateUserAccountCommandHandler(IUserAccountInfoRepository userAccountInfoRepository, IMapper mapper, UserAccountBusinessRules userAccountBusinessRules)
            {
                _userAccountInfoRepository = userAccountInfoRepository;
                _mapper = mapper;
                _userAccountBusinessRules = userAccountBusinessRules;
            }

            public async Task<UpdatedUserAccountResponse> Handle(UpdateUserAccountCommand command, CancellationToken cancellationToken)
            {
                await _userAccountBusinessRules.UserAccountNotFound(command.Request.Id);
                _userAccountBusinessRules.UserEmailIsNotValid(command.Request.Email);
                _userAccountBusinessRules.UserPasswordIsNotValid(command.Request.Password);

                var userAccount = await _userAccountInfoRepository.GetAsync(ua => ua.Id == command.Request.Id);
                _mapper.Map(command.Request, userAccount); // bu satırı diğerleri için de ekle yoksa güncelleme çalışmıyor.

                var updatedUserAccount = await _userAccountInfoRepository.UpdateAsync(userAccount);

                var response = _mapper.Map<UpdatedUserAccountResponse>(updatedUserAccount);
                response.Message = UserAccountMessages.UserAccountUpdated;
                return response;
            }
        }
    }
}
