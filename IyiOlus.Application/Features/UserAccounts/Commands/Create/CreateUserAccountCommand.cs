using AutoMapper;
using IyiOlus.Application.Features.UserAccounts.Constants;
using IyiOlus.Application.Features.UserAccounts.Dtos.Requests;
using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Application.Features.UserAccounts.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Commands.Create
{
    public class CreateUserAccountCommand:IRequest<CreatedUserAccountResponse>
    {
        public CreateUserAccountRequest Request { get; set; } = default!;

        public class CreateUserACcountCommandHandler : IRequestHandler<CreateUserAccountCommand, CreatedUserAccountResponse>
        {
            private readonly IUserAccountInfoRepository _userAccountInfoRepository;
            private readonly IMapper _mapper;
            private readonly UserAccountBusinessRules _userAccountBusinessRules;

            public CreateUserACcountCommandHandler(IUserAccountInfoRepository userAccountInfoRepository, IMapper mapper, UserAccountBusinessRules userAccountBusinessRules)
            {
                _userAccountInfoRepository = userAccountInfoRepository;
                _mapper = mapper;
                _userAccountBusinessRules = userAccountBusinessRules;
            }

            public async Task<CreatedUserAccountResponse> Handle(CreateUserAccountCommand command, CancellationToken cancellationToken)
            {
                _userAccountBusinessRules.UserEmailIsNotValid(command.Request.Email);
                _userAccountBusinessRules.UserPasswordIsNotValid(command.Request.Password);

                var userAccount = _mapper.Map<UserAccountInfo>(command.Request);

                var createdUserAccount = await _userAccountInfoRepository.AddAsync(userAccount);

                var response = _mapper.Map<CreatedUserAccountResponse>(createdUserAccount);
                response.Message = UserAccountMessages.UserAccountCreated;

                return response;
            }
        }
    }
}
