using IyiOlus.Domain.Entities;
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
        public Guid UserProfileId { get; set; }
        public Profile Profile { get; set; }  // buradaki profile enum'u algoritma dll'den geliyor
        public Profile? OldProfile { get; set; } // kullanıcı yeni profile belirlediğinde eski profil buraya yazılacak
        public bool State { get; set; }  // önceki profile göre iyileşme olup olmadığı
        public DateTime ProfileTestDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        //public Guid UserId { get; set; }
        //public User User { get; set; } = default!;
        //public Guid ProfileTypeId { get; set; }
        //public ProfileType ProfileType { get; set; } = default!;
    }
}
