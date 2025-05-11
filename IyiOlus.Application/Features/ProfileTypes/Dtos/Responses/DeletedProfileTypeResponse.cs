using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IyiOlus.Application.Features.ProfileTypes.Dtos.Responses
{
    public class DeletedProfileTypeResponse
    {
        public Guid ProfileTypeId { get; set; }
        public string Message { get; set; } = default!;
    }
}
