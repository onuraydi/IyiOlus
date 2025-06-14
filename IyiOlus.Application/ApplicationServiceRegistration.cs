using FluentValidation;
using IyiOlus.Application.Features.Authentications;
using IyiOlus.Application.Features.Authentications.Login.Rules;
using IyiOlus.Application.Features.Authentications.RefreshToken.Rules;
using IyiOlus.Application.Features.Authentications.Register.Rules;
using IyiOlus.Application.Features.Authentications.Revoke.Rules;
using IyiOlus.Application.Features.Contacts.Rules;
using IyiOlus.Application.Features.DailyMoods.Rules;
using IyiOlus.Application.Features.ProfileTypes.Rules;
using IyiOlus.Application.Features.Questions.Rules;
using IyiOlus.Application.Features.Settings.Rules;
using IyiOlus.Application.Features.UserProfiles.Rules;
using IyiOlus.Application.Features.Users.Rules;
using IyiOlus.Application.Services.Repositories.AuthRepositories;
using IyiOlus.Core.CrossCuttingConcerns.Exceptions.Handlers;
using Microsoft.Extensions.DependencyInjection;
using OWBAlgorithm.Services.AnswerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            services.AddSingleton<HttpExceptionHandler>();

            services.AddScoped<IAuthenticatedUserRepository, AuthenticatedUserManager>();

            services.AddScoped<ContactBusinessRules>();
            services.AddScoped<DailyMoodBusinessRules>();
            services.AddScoped<ProfileTypeBusinessRules>();
            services.AddScoped<QuestionBusinessRules>();
            services.AddScoped<SettingBusinessRules>();
            services.AddScoped<UserProfileBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddScoped<AnswerManager>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<LoginBusinessRules>();
            services.AddScoped<RefreshTokenBusinessRules>();
            services.AddScoped<RevokeBusinessRules>();

            return services;
        }
    }
}