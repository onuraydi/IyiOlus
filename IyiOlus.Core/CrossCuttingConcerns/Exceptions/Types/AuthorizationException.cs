﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.CrossCuttingConcerns.Exceptions.Types
{
    public class AuthorizationException:Exception
    {
        public AuthorizationException(string message): base(message) { }
    }
}
