using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IyiOlus.Core.Mail.Repositories
{
    public interface IMailSenderRepository
    {
        Task SendMailAsync(string toMail,string code);
    }
}
