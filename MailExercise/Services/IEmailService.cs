using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailExercise.Services
{
    public interface IEmailService
    {
        void Send(string address, string code);
    }
}
