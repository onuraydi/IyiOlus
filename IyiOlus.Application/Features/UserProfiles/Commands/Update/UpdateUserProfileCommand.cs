using AutoMapper;
using IyiOlus.Application.Features.UserProfiles.Constants;
using IyiOlus.Application.Features.UserProfiles.Dtos.Requests;
using IyiOlus.Application.Features.UserProfiles.Dtos.Responses;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Services.Repositories;
using MediatR;
using OWBAlgorithm.Services.AnswerServices;
using OWBAlgorithm.Services.EvaluationServices;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Commands.Update
{
    public class UpdateUserProfileCommand:IRequest<UpdatedUserProfileResponse>
    {
        public UpdateUserProfileRequest Request { get; set; } = default!;
        public List<bool> answers = new List<bool>();

        public class UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommand, UpdatedUserProfileResponse>
        {
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly UserProfileBusinessRules _userProfileBusinessRules;
            private readonly AnswerManager _answerManager;
            public UpdateUserProfileCommandHandler(IUserProfileRepository userProfileRepository, IMapper mapper, UserProfileBusinessRules userProfileBusinessRules, AnswerManager answerManager)
            {
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _userProfileBusinessRules = userProfileBusinessRules;
                _answerManager = answerManager;
            }

            public async Task<UpdatedUserProfileResponse> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
            {
                await _userProfileBusinessRules.UserProfileNotFound(command.Request.Id);

                //await _userProfileBusinessRules.UserProfileBlock(command.Request.UserId, command.Request.ProfileTestDate);

                command.answers.AddRange(command.Request.answers);
                _answerManager.AddAnswer(command.answers);

                EvaluationManager evaluationManager = new EvaluationManager(_answerManager);
                var evaluations = evaluationManager.SelecetEvaluation();

                ProfileManager profileManager = new ProfileManager(evaluationManager);
                var profile = profileManager.GetProfile();

                var userProfile = await _userProfileRepository.GetAsync(up => up.Id == command.Request.Id);
                var oldProfile = userProfile.Profile;
                _mapper.Map(command.Request, userProfile);
                
                userProfile.OldProfile = oldProfile;
                userProfile.Evaluations = evaluations;
                userProfile.Profile = profile;

                if(userProfile.OldProfile < userProfile.Profile)
                {
                    userProfile.State = true;
                }
                
                _userProfileBusinessRules.UserProfileNotPossible(userProfile);
                var updatedUserProfile = await _userProfileRepository.UpdateAsync(userProfile);

                var response = _mapper.Map<UpdatedUserProfileResponse>(updatedUserProfile);
                response.Message = UserProfileMessages.UserProfileUpdated;

                return response;
            }
        }
    }
}
