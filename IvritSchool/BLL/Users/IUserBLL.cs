using IvritSchool.Entities;
using IvritSchool.Enums;

namespace IvritSchool.BLL.Users
{
    public interface IUserBLL
    {
        void Add(BotUser user);
        void Edit(BotUser user);
        bool IsBanned(long tid);
        BotUser GetByID(int id);
        BotUser GetByTID(long tid);
        void SetStaus(long tid, UserStatus status);
    }
}
