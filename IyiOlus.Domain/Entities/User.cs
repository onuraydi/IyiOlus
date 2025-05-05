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
        public Guid UserId { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public WorkState WorkState { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public bool Gender { get; set; }   
        public bool Relation { get; set; }  // Bireyin ilişkisini ifade eder.
        public virtual UserAccountInfo UserAccountInfo { get; set; } = default!;
        public virtual UserRole UserRole { get; set; } = default!;
        public virtual Setting Setting { get; set; } = default!;
    }
}
