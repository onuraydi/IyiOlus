using IyiOlus.Application.Features.UserAccounts.Constants;
using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Application.Features.UserAccounts.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserAccounts.Commands.Delete
{
    public class DeleteUserAccountCommand:IRequest<DeletedUserAccountResponse>
    {
        public Guid UserAccountId { get; set; }
        public class DeleteUserAccountCommandHandler : IRequestHandler<DeleteUserAccountCommand, DeletedUserAccountResponse>
        {
            private readonly IUserAccountInfoRepository _userAccountInfoRepository;
            private readonly UserAccountBusinessRules _userAccountBusinessRules;

            public DeleteUserAccountCommandHandler(IUserAccountInfoRepository userAccountInfoRepository, UserAccountBusinessRules userAccountBusinessRules)
            {
                _userAccountInfoRepository = userAccountInfoRepository;
                _userAccountBusinessRules = userAccountBusinessRules;
            }

            public async Task<DeletedUserAccountResponse> Handle(DeleteUserAccountCommand request, CancellationToken cancellationToken)
            {
                await _userAccountBusinessRules.UserAccountNotFound(request.UserAccountId);

                var userAccount = await _userAccountInfoRepository.GetAsync(ua => ua.Id == request.UserAccountId);

                if (userAccount != null)
                    await _userAccountInfoRepository.DeleteAsync(userAccount);

                return new DeletedUserAccountResponse
                {
                    Id = request.UserAccountId,
                    Message = UserAccountMessages.UserAccountDeleted,
                };
            }
        }
    }
}
