using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Services.Repositories
{
    // test kolaylığı için
    public interface IDateTimeProvider
    {
        DateTimeOffset UtcNow { get; }
    }
}
