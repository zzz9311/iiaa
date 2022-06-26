using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IvritSchool.Entities;
using IvritSchool.Enums.Answers;

namespace IvritSchool.BLL.PayedUsers
{
    public interface IPayedUser
    {
        Entities.PayedUsers FindByEmail(string email);
        SetPayedUserStatus SetUser(long tid, string email);
        void Edit(Entities.PayedUsers payedUser);
    }
}
