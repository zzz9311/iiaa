using IvritSchool.Entities;

namespace IvritSchool.BLL.Users
{
    public interface IUserBLL
    {
        void Add(BotUser user);
        void Edit(BotUser user);
        bool IsBanned(long tid);
        BotUser GetByID(int id);
        BotUser GetByTID(long tid);
    }
}
