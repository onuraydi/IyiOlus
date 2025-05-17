using IyiOlus.Application.Services.Repositories;
using IyiOlus.Persistence.Contexts;
using IyiOlus.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Persistence
{
    public static class PersistanceServiceRegistiration
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IDailyMoodRepository, DailyMoodRepository>();
            services.AddScoped<IProfileTypeRepository, ProfileTypeRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<ISettingRepository, SettingRepository>();
            services.AddScoped<IUserAccountInfoRepository, UserAccountRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
