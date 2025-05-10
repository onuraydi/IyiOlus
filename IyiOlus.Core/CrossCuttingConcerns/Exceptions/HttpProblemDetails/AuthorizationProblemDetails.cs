using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class AuthorizationProblemDetails:ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Authorization Error";
            Detail = detail;
            Status = StatusCodes.Status401Unauthorized;
            Type = "https://HataDetaySayfasiGelecek";
        }
    }
}
