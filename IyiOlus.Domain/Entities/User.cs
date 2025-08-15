using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class User:Entity<Guid>
    {
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public WorkState WorkState { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public bool Gender { get; set; }   
        public bool Relation { get; set; }  // Bireyin ilişkisini ifade eder.
        public virtual Setting Setting { get; set; } = default!;
        public virtual ApplicationUser ApplicationUser { get; set; } = default!;
        public Guid ApplicationUserId { get; set; }
        public virtual ICollection<DailyMood> DailyMoods { get; set; } = default!;
        public virtual ICollection<Contact> Contacts { get; set; } = default!;
        public virtual ICollection<UserProfile> UserProfiles { get; set; } = default!;
        public virtual ICollection<Exercise> Exercises { get; set; } = default!;
    }
}
