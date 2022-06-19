using IvritSchool.Data;
using IvritSchool.Finder;
using IvritSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.Days
{
    public class DayBLL : IDayBLL
    {
        private readonly IRepository<Entities.Days> _repository;
        private readonly IFinder<Entities.Days> _finder;
        private readonly ISaveChangesCommand _saveChangesCommand;
        public DayBLL(IRepository<Entities.Days> repository,
                       IFinder<Entities.Days> finder,
                       ISaveChangesCommand saveChangesCommand)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
        }
        public void Insert(Entities.Days day)
        {
            var DayNumberExists = _repository.Find(x => x.DayNumber == day.DayNumber);

            if (DayNumberExists != null)
            {
                throw new ArgumentException("День с таким номером уже существует");
            }

            _repository.Insert(day);
            _saveChangesCommand.SaveChanges();
        }


        public Entities.Days[] GetDays(string daysPredicate)
        {
            var daysIds = GetDaysIDs(daysPredicate);

            var days = _repository.ToArray(x => daysIds.Contains(x.DayNumber));

            return days;
        }

        private List<int> GetDaysIDs(string daysPredicate)
        {
            List<int> dayNumbers = new List<int>();
            List<string> splittedDays = daysPredicate.Split(',').ToList();
            
            foreach(var el in splittedDays)
            {
                try
                {
                    if (el.Contains("-"))
                    {
                        var splitNumberString = el.Split("-");
                        if (splitNumberString.Length == 2)
                        {
                            var start = Convert.ToInt32(splitNumberString[0]);
                            var count = Convert.ToInt32(splitNumberString[1]) - start + 1;
                            dayNumbers.AddRange(Enumerable.Range(start, count));
                        }
                        continue;
                    }
                    dayNumbers.Add(Convert.ToInt32(el));
                }
                catch (Exception)
                {
                }
            }

            return dayNumbers.Distinct().ToList();
        }
    }
}
