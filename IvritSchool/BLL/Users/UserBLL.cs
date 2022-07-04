using IvritSchool.Data;
using IvritSchool.Entities;
using IvritSchool.Enums;
using IvritSchool.Finder;
using IvritSchool.Repository;

namespace IvritSchool.BLL.Users
{
    public class UserBLL : IUserBLL
    {
        private readonly IRepository<BotUser> _repository;
        private readonly IFinder<BotUser> _finder;
        private readonly ISaveChangesCommand _saveChangesCommand;
        public UserBLL(IRepository<BotUser> repository,
                       IFinder<BotUser> finder,
                       ISaveChangesCommand saveChangesCommand)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
        }
        public void Add(BotUser user)
        {
            _repository.Insert(user);
            _saveChangesCommand.SaveChanges();
        }

        public bool IsBanned(long tid)
        {
            var user = _repository.Find(x => x.TID == tid);
            return user == null ? false : user.IsBanned;
        }

        public BotUser GetByID(int id)
        {
            return _finder.Find(id);
        }

        public BotUser GetByTID(long tid)
        {
            return _repository.Find(x => x.TID == tid);
        }

        public void Edit(BotUser user)
        {
            var changingUser = _finder.Find(user.ID);
            if (user == null)
            {
                return;
            }
            changingUser.IsBanned = user.IsBanned;

            _saveChangesCommand.SaveChanges();
        }

        public void SetStaus(long tid, UserStatus status)
        {
            var user = _repository.Find(x => x.TID == tid);
            if(user != null)
            {
                user.Status = status;
                _saveChangesCommand.SaveChanges();
            }
        }

        public BotUser[] GetList()
        {
            return _repository.ToArray();
        }
    }
}
