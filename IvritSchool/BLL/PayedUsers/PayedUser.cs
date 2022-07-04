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
        private readonly IRepository<Entities.Tariff> _tariffRepository;
        private readonly IFinder<Entities.PayedUsers> _finder;
        private readonly ISaveChangesCommand _saveChangesCommand;
        private readonly IUserBLL _userBLL;
        public PayedUser(IRepository<Entities.PayedUsers> repository,
                         IFinder<Entities.PayedUsers> finder,
                         ISaveChangesCommand saveChangesCommand,
                         IUserBLL userBLL, 
                         IRepository<Entities.Tariff> tariffRepository)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
            _userBLL = userBLL;
            _tariffRepository = tariffRepository;
        }

        public void Add(Entities.PayedUsers payedUser, int? tariffID = null)
        {
            if(tariffID.HasValue)
            {
                var tariff = _tariffRepository.Include(x => x.Days).Find(x => x.ID == tariffID);
                ThrowHelper.ThrowIfNull(tariff, "Tariff was null");
                if(tariff.Days.Count() > 0)
                {
                    payedUser.CurrentDay = tariff.Days.ElementAt(0);
                }
            }

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
            oldPayedUser.StartFrom = payedUser.StartFrom;

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
            if (payedUser == null)
            {
                return SetPayedUserStatus.IsUsing;
            }
            

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

        public void RecalculateNextMessage(int[] userIDs)
        {
            var payedUsers = _repository.Include(x => x.User).ToArray(x => userIDs.Contains(x.ID));

            foreach(var el in payedUsers)
            {
                if (el.NextDay == null)
                {
                    el.ClientStatus = Enums.ClientStatus.Ended;
                    continue;
                }

                el.CurrentDay = el.NextDay;
            }

            _saveChangesCommand.SaveChanges();
        }
    }
}
