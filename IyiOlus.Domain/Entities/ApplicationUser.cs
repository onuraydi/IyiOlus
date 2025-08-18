using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Domain.Entities
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string FullName { get; set; } = default!;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public virtual User User { get; set; } = default!;
        public string FcmToken { get; set; } = default!; // Firebase Cloud Messaging için gerekli 
    }
}
