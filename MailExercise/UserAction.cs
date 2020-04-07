using MailExercise.Models;
using MailExercise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailExercise
{
    public class UserAction : IUserAction
    {
        private readonly UserLists _userLists;

        public UserAction(UserLists userLists)
        {
            _userLists = userLists;
        }
        public void Add(User user)
        {
            _userLists.Users.Add(user);
        }

        public bool Valid(string email, string code)
        {
            var user = _userLists.Users.SingleOrDefault(e => e.Email == email);
            if(user == null)
            {
                return false;
            }
            if(user.ValidationCode != code)
            {
                return false;
            }
            return true;
        }
    }
}
