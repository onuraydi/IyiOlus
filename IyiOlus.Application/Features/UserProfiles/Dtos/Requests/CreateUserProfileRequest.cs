using IyiOlus.Domain.Entities;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.UserProfiles.Dtos.Requests
{
    public class CreateUserProfileRequest
    {
        public Profile Profile { get; set; }  // buradaki profile enum'u algoritma dll'den geliyor
        public Profile? OldProfile { get; set; } // kullanıcı yeni profile belirlediğinde eski profil buraya yazılacak
        public bool State { get; set; }  // önceki profile göre iyileşme olup olmadığı
        public DateTime ProfileTestDate { get; set; }
        public Guid UserId { get; set; }
        public Guid ProfileTypeId { get; set; }
    }
}
