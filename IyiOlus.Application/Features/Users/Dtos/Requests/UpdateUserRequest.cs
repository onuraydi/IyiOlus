using IyiOlus.Domain.Entities;
using IyiOlus.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Users.Dtos.Requests
{
    public class UpdateUserRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public DateTime DateOfBirth { get; set; }
        public WorkState WorkState { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public bool Gender { get; set; }
        public bool Relation { get; set; }  // Bireyin ilişkisini ifade eder.
    }
}
