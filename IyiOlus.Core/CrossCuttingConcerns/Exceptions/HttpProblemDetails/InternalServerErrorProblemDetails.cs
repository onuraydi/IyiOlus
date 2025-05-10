﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    public class InternalServerErrorProblemDetails:ProblemDetails
    {
        public InternalServerErrorProblemDetails(string detail)
        {
            Title = "Internal server error";
            Detail = detail;
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://yonlendirileceksayfa";
        }
    }
}
