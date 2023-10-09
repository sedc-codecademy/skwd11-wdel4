using SEDC.Lamazon.ViewModels.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IEmailService
    {
        void SendEmail(EmailViewModel emailViewModel);
    }
}
