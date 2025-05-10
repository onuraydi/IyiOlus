using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class ValidationProblemDetails:ProblemDetails
    {
        public ValidationProblemDetails(string detail)
        {
            Title = "Validation error(s)";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest;
            Type = "https://";
        }
    }
}
