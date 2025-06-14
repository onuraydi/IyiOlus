using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.Repositories.Token
{
    public class TokenSettings
    {
        public string Audience { get; set; } = default!;
        public string Issuer { get; set; } = default!;
        public string Secret { get; set; } = default!;
        public int TokenValidityInMinutes { get; set; }
        //public int RefreshTokenValidityInDays { get; set; }

    }
}
