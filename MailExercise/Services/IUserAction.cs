using MailExercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailExercise.Services
{
    public interface IUserAction
    {
        void Add(User user);

        bool Valid(string email, string code);
    }
}
