using IyiOlus.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Persistence.Contexts
{
    public class BaseDbContext:IdentityDbContext<ApplicationUser,Role,Guid>
    {
        public BaseDbContext() { }
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<DailyMood> DailyMoods { get; set; }
        public DbSet<ProfileType> ProfileTypes { get;set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
