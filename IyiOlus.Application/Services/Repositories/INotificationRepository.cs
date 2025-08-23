using IyiOlus.Core.Repositories;
using IyiOlus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Application.Services.Repositories
{
    public interface INotificationRepository:IAsyncRepository<Notification,Guid>
    {
        Task<List<Notification>> GetPreferredTimeAsync(TimeOnly time,DateTime dateTime, CancellationToken cancellationToken);
    }
}
