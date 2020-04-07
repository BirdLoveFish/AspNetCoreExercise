using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailExercise.Models
{
    public class User
    {
        public User()
        {

        }

        public User(string email, string code)
        {
            Email = email;
            ValidationCode = code;
        }

        public string Email { get; set; }
        public string ValidationCode { get; set; }
    }
}
