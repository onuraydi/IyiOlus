﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.Exceptions.Types
{
    public class ValidationException:Exception
    {
        public ValidationException(string message) : base(message) { }
    }
}
