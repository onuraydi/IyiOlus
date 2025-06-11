using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Constants;
using IyiOlus.Application.Features.UserProfiles.Dtos.Requests;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Services.Repositories;
using IyiOlus.Domain.Entities;
using MediatR;
using OWBAlgorithm.Services.AnswerServices;
using OWBAlgorithm.Services.EvaluationServices;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Commands.Create
{
    public class CreateUserProfileCommand:IRequest<CreatedUserProfileResponse>
    {
        public CreateUserProfileRequest Request { get; set; } = default!;
        public List<bool> answers = new List<bool>();

        public class CreateUserProfileCommandHandler : IRequestHandler<CreateUserProfileCommand, CreatedUserProfileResponse>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;
            private readonly AnswerManager _answerManager;

            public CreateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules, AnswerManager answerManager)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
                _answerManager = answerManager;
            }

            public async Task<CreatedUserProfileResponse> Handle(CreateUserProfileCommand command, CancellationToken cancellationToken)
            {
                //await _userProfileBusinessRules.UserProfileBlock(command.Request.UserId, command.Request.ProfileTestDate);
                // bunu açma çünkü burada değişiklik oldu kullanıcı günde 3 kez profilleme yapabilir

                command.answers.AddRange(command.Request.answers);

                _answerManager.AddAnswer(command.answers);
                EvaluationManager evaluationManager = new EvaluationManager(_answerManager);
                var evaluations =evaluationManager.SelecetEvaluation();

                ProfileManager profileManager = new ProfileManager(evaluationManager);
                var profile = profileManager.GetProfile();

                var userProfile = _mapper.Map<UserProfile>(command.Request);
                userProfile.Profile = profile;
                userProfile.Evaluations = evaluations;
                userProfile.State = false;

                _userProfileBusinessRules.UserProfileNotPossible(userProfile);

                var createdUserProfile = await _userProfileRepository.AddAsync(userProfile);

                var response = _mapper.Map<CreatedUserProfileResponse>(createdUserProfile);
                response.Message = UserProfileMessages.UserProfileCreated;
                return response;
            }
        }
    }
}
