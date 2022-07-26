using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commons.EmailConfigurations
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message ,string path);
    }
}
