using IyiOlus.Application.Features.ProfileTypes.Dtos.Responses;
using IyiOlus.Application.Features.Users.Dtos.Responses;
using IyiOlus.Domain.Entities;
using OWBAlgorithm.Services.EvaluationServices;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Dtos.Responses
{
    public class UserProfileResponse
    {
        public Guid Id { get; set; }
        public Profile Profile { get; set; }  // buradaki profile enum'u algoritma dll'den geliyor
        public Profile? OldProfile { get; set; } // kullanıcı yeni profile belirlediğinde eski profil buraya yazılacak
        public bool State { get; set; }  // önceki profile göre iyileşme olup olmadığı
        public DateTime ProfileTestDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public virtual UserResponse UserResponse { get; set; } = default!;
        public virtual ProfileTypeResponse ProfileTypeResponse { get; set; } = default!;
        public List<Evaluation> Evaluations { get; set; } = new();
    }
}
