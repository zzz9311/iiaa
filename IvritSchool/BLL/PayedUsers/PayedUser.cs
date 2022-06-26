using IvritSchool.BLL.Users;
using IvritSchool.Data;
using IvritSchool.Enums.Answers;
using IvritSchool.Finder;
using IvritSchool.Helpers;
using IvritSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.PayedUsers
{
    public class PayedUser : IPayedUser
    {
        private readonly IRepository<Entities.PayedUsers> _repository;
        private readonly IFinder<Entities.PayedUsers> _finder;
        private readonly ISaveChangesCommand _saveChangesCommand;
        private readonly IUserBLL _userBLL;
        public PayedUser(IRepository<Entities.PayedUsers> repository,
                         IFinder<Entities.PayedUsers> finder,
                         ISaveChangesCommand saveChangesCommand, 
                         IUserBLL userBLL)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
            _userBLL = userBLL;
        }

        public void Add(Entities.PayedUsers payedUser)
        {
            _repository.Insert(payedUser);
            payedUser.ClientStatus = Enums.ClientStatus.NotStuding;
            _saveChangesCommand.SaveChanges();
        }

        public void Edit(Entities.PayedUsers payedUser)
        {
            var oldPayedUser = _finder.Find(payedUser.ID);

            if (oldPayedUser == null)
            {
                throw new ArgumentNullException("Не найден пользователь");
            }

            oldPayedUser.ClientStatus = payedUser.ClientStatus;
            oldPayedUser.Email = payedUser.Email;
            oldPayedUser.Name = payedUser.Name;
            oldPayedUser.SureName = payedUser.SureName;
            oldPayedUser.Tariff = payedUser.Tariff;

            _saveChangesCommand.SaveChanges();
        }

        public Entities.PayedUsers FindByEmail(string email)
        {
            return _repository.Find(x => x.Email == email);
        }

        public SetPayedUserStatus SetUser(long tid, string email)
        {
            var user = _userBLL.GetByTID(tid);
            ThrowHelper.ThrowIfNull(user, $"user {tid}");

            var payedUser = FindByEmail(email);
            ThrowHelper.ThrowIfNull(payedUser, $"payedUser");

            if (payedUser.ClientStatus != Enums.ClientStatus.NotStuding)
            {
                return SetPayedUserStatus.IsUsing;
            }

            payedUser.User = user;
            payedUser.ClientStatus = Enums.ClientStatus.Studing;
            payedUser.LearnStartsFrom = DateTime.Now;
            payedUser.PasswordType = Enums.PasswordType.NotActive; //?????

            _saveChangesCommand.SaveChanges();

            return SetPayedUserStatus.OK;
        }
    }
}
