using IvritSchool.Data;
using IvritSchool.Repository;
using IvritSchool.Senders;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.SendersLogic
{
    public class LessonSenderBLL : ILessonSenderBLL
    {
        private readonly IRepository<Entities.PayedUsers> _payedUsersRepository;
        private readonly ISender _sender;
        private readonly ISaveChangesCommand _saveChangesCommand;
        private readonly IRepository<Entities.Days> _daysRepository;
        public LessonSenderBLL(IRepository<Entities.PayedUsers> payedUsersRepository,
                               ISender sender,
                               ISaveChangesCommand saveChangesCommand, 
                               IRepository<Entities.Days> daysRepository)
        {
            _payedUsersRepository = payedUsersRepository;
            _sender = sender;
            _saveChangesCommand = saveChangesCommand;
            _daysRepository = daysRepository;
        }

        public async Task SendAsync()
        {
            var days = _daysRepository.Include(x => x.Messages).ToArray();
            var payedUsers = _payedUsersRepository.Include(x => x.User)
                                                  .Include(x => x.Tariff)
                                                  .Include(x => x.Tariff.Days)
                                                  .Include(x => x.CurrentDay)
                                                  .ToArray(x => x.ClientStatus == Enums.ClientStatus.Studing);
            var client = await Bot.Bot.Get();

            foreach (var el in payedUsers)
            {
                try
                {
                    var dayToSend = days.Where(i => i.DayNumber == el.CurrentDay.DayNumber).FirstOrDefault();

                    if (dayToSend == null)
                    {
                        continue;
                    }

                    foreach (var lesson in dayToSend.Messages)
                    {
                        try
                        {
                            await _sender.SendMessage(lesson, el.User.TID, el.Tariff, client);
                        }
                        catch (System.Exception)
                        {
                        }

                    }

                    var dayIndex = el.Tariff.Days.ToList().FindIndex(a => a == dayToSend);

                    if (dayIndex != -1)
                    {
                        if (dayIndex == el.Tariff.Days.Count() - 1)
                        {
                            el.ClientStatus = Enums.ClientStatus.Ended;
                            continue;
                        }

                        var nextDay = el.Tariff.Days.ToArray()[dayIndex + 1];
                        if (nextDay != null)
                        {
                            el.CurrentDay = nextDay;
                        }
                    }
                }
                catch (System.Exception)
                {

                }
            }

            _saveChangesCommand.SaveChanges();
        }
    }
}
