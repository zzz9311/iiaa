using IvritSchool.Data;
using IvritSchool.Entities;
using IvritSchool.Enums;
using IvritSchool.Finder;
using IvritSchool.Helpers;
using IvritSchool.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.BLL.Messages
{
    public class MessageBLL : IMessageBLL
    {
        private readonly IRepository<Message> _repository;
        private readonly IFinder<Message> _finder;
        private readonly IRepository<Entities.Days> _daysRepository;
        private readonly IRepository<Entities.PayedUsers> _payedUsersRepository;
        private readonly ISaveChangesCommand _saveChangesCommand;

        public MessageBLL(IRepository<Message> repository,
                          IFinder<Message> finder,
                          ISaveChangesCommand saveChangesCommand,
                          IRepository<Entities.Days> daysRepository, 
                          IRepository<Entities.PayedUsers> payedUsersRepository)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
            _daysRepository = daysRepository;
            _payedUsersRepository = payedUsersRepository;
        }

        public void Delete(int id)
        {
            var message = _finder.Find(id);
            ThrowHelper.ThrowIfNull(message, "Сообщение равно нулю");
            _repository.Delete(message);
            _saveChangesCommand.SaveChanges();
        }

        public void Insert(Entities.Message message)
        {
            _repository.Insert(message);
            _saveChangesCommand.SaveChanges();
        }

        public void Update(Entities.Message message)
        {
            var newMessage = _finder.Find(message.ID);
            newMessage.Text = message.Text;
            newMessage.VIP = message.VIP;
            newMessage.Path = message.Path;
            _saveChangesCommand.SaveChanges();
        }

        public List<MessagesToSend> GetActuallyMessages()
        {
            //List<Message> actuallyMessages = new List<Message>();
            List<MessagesToSend> actuallyMessages = new List<MessagesToSend>();
            var days = _daysRepository.Include(x => x.Messages).ToArray();

            var payedUsers = _payedUsersRepository.Include(x => x.User)
                                                  .Include(x => x.Tariff)
                                                  .Include(x => x.Tariff.Days)
                                                  .Include(x => x.CurrentDay)
                                                  .ToArray(x => x.ClientStatus == ClientStatus.Studing && x.StartFrom < DateTime.Now);

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
                            if (!el.Tariff.VIP && lesson.VIP)
                            {
                                continue;
                            }

                            //actuallyMessages.Add(lesson);
                            actuallyMessages.Add(new MessagesToSend()
                            {
                                User = el.User,
                                Sent = false,
                                Error = false,
                                Messages = lesson,
                                SendTime = lesson.SendTime
                            });

                        }
                        catch (System.Exception ex)
                        {
                        }
                    }

                    var dayIndex = el.Tariff.Days.ToList().FindIndex(a => a == dayToSend);

                    if (dayIndex != -1)
                    {
                        if (dayIndex >= el.Tariff.Days.Count() - 1)
                        {
                            el.NextDay = null;
                            //el.ClientStatus = ClientStatus.Ended;
                            continue;
                        }

                        var nextDay = el.Tariff.Days.ToArray()[dayIndex + 1];

                        if (nextDay == null)
                        {
                            while(nextDay == null)
                            {
                                nextDay = el.Tariff.Days.ToArray()[dayIndex + 1];
                                dayIndex++;
                            }
                        }

                        el.NextDay = nextDay;

                    }
                }
                catch (Exception ex)
                {
                    el.ClientStatus = ClientStatus.Pause;
                }
            }

            _saveChangesCommand.SaveChanges(); //very scary thing when messages not sent yet
            return actuallyMessages;
        }
    }
}
