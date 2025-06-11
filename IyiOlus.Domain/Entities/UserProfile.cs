using IyiOlus.Core.Repositories;
using OWBAlgorithm.Services.EvaluationServices;
using OWBAlgorithm.Services.ProfileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class UserProfile:Entity<Guid>
    {
        public Profile Profile { get; set; }  // buradaki profile enum'u algoritma dll'den geliyor
        public Profile? OldProfile { get; set; } // kullanıcı yeni profile belirlediğinde eski profil buraya yazılacak
        public bool State { get; set; }  // önceki profile göre iyileşme olup olmadığı
        public DateTime ProfileTestDate { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public Guid ProfileTypeId { get; set; }
        public ProfileType ProfileType { get; set; } = default!;
        public List<Evaluation> Evaluations { get; set; } = new();
    }
}
