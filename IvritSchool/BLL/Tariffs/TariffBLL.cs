using IvritSchool.BLL.Days;
using IvritSchool.Data;
using IvritSchool.Entities;
using IvritSchool.Finder;
using IvritSchool.Helpers;
using IvritSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.Tariffs
{
    public class TariffBLL : ITariffBLL
    {
        private readonly IRepository<Tariff> _repository;
        private readonly IFinder<Tariff> _finder;
        private readonly ISaveChangesCommand _saveChangesCommand;
        private readonly IDayBLL _dayBLL;

        public TariffBLL(IRepository<Tariff> repository,
                       IFinder<Tariff> finder,
                       ISaveChangesCommand saveChangesCommand, 
                       IDayBLL dayBLL)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
            _dayBLL = dayBLL;
        }

        public void DeleteTariff(int id)
        {
            var tariff = _finder.Find(id);
            ThrowHelper.ThrowIfNull(tariff, "Тариф равен нулю");
            _repository.Delete(tariff);
            _saveChangesCommand.SaveChanges();
        }

        public void Edit(Tariff tariff, string daysPredicate)
        {
            var oldTariff = _finder.Find(tariff.ID);

            if (oldTariff == null)
            {
                throw new ArgumentException("Тариф не был найден");
            }

            if (!string.IsNullOrEmpty(daysPredicate))
            {
                oldTariff.Days = _dayBLL.GetDays(daysPredicate);
            }

            oldTariff.VIP = tariff.VIP;
            oldTariff.Name = tariff.Name;

            _saveChangesCommand.SaveChanges();
        }

        public Tariff Get(int id)
        {
            return _finder.Find(id);
        }

        public Tariff[] GetList()
        {
            return _repository.ToArray();
        }

        public void Insert(Tariff tariff, string daysPredicate = null)
        {
            if (!string.IsNullOrEmpty(daysPredicate))
            {
                var days = _dayBLL.GetDays(daysPredicate);
                if (days.Length > 0)
                {
                    tariff.Days = days;
                }
            }

            _repository.Insert(tariff);
            _saveChangesCommand.SaveChanges();
        }
    }
}
