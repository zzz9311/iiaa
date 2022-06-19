using IvritSchool.BLL.Days;
using IvritSchool.Data;
using IvritSchool.Entities;
using IvritSchool.Finder;
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
