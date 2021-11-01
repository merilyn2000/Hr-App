using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp_WebAPI.BusinessLogic.Email2
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
