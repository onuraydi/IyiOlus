using IyiOlus.Application.Features.UserAccounts.Dtos.Responses;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Dtos.Responses
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public WorkState WorkState { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public bool Gender { get; set; }
        public bool Relation { get; set; }  // Bireyin ilişkisini ifade eder.
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserAccountResponse UserAccountResponse { get; set; } = default!;

        //public virtual UserAccountInfo UserAccountInfo { get; set; } = default!;
        //public virtual Setting Setting { get; set; } = default!;

        //public virtual ICollection<Daily> Dailies { get; set; } = default!;
        //public virtual ICollection<DailyMood> DailyMoods { get; set; } = default!;
        //public virtual ICollection<Contact> Contacts { get; set; } = default!;
        //public virtual ICollection<UserProfile> UserProfiles { get; set; } = default!;
    }
}
