using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Features.Settings.Dtos.Responses
{
    public class CreatedSettingResponse
    {
        public Guid SettingId { get; set; }
        public TimeSpan NotificationTime { get; set; }
        public bool isActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Message { get; set; } = default!;
    }
}
