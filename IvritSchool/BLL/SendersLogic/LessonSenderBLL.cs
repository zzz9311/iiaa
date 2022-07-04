using IvritSchool.BLL.Users;
using IvritSchool.Data;
using IvritSchool.Repository;
using IvritSchool.Senders;
using System.Linq;
using System.Threading.Tasks;
using System;
using IvritSchool.Entities;
using IvritSchool.BLL.Messages;
using IvritSchool.BLL.PayedUsers;

namespace IvritSchool.BLL.SendersLogic
{
    public class LessonSenderBLL : ILessonSenderBLL
    {
        private readonly IRepository<Entities.PayedUsers> _payedUsersRepository;
        private readonly IPayedUser _payedUserBLL;
        private readonly ISender _sender;
        private readonly ISaveChangesCommand _saveChangesCommand;
        private readonly IUserBLL _userBLL;
        private readonly IRepository<MessagesToSend> _messageToSendRepository;
        private readonly IMessageBLL _messageBLL;
        public LessonSenderBLL(IRepository<Entities.PayedUsers> payedUsersRepository,
                               ISender sender,
                               ISaveChangesCommand saveChangesCommand,
                               IUserBLL userBLL,
                               IRepository<MessagesToSend> messageToSendRepository,
                               IMessageBLL messageBLL, 
                               IPayedUser payedUserBLL)
        {
            _payedUsersRepository = payedUsersRepository;
            _sender = sender;
            _saveChangesCommand = saveChangesCommand;
            _userBLL = userBLL;
            _messageToSendRepository = messageToSendRepository;
            _messageBLL = messageBLL;
            _payedUserBLL = payedUserBLL;
        }


        public async Task SendAsync(Message message)
        {
            var client = await Bot.Bot.Get();
            var users = _userBLL.GetList();
            foreach (var el in users)
            {
                await _sender.SendMessage(message, el.TID, client);
            }
        }

        public async Task SendAsync()
        {
            var messages = _messageToSendRepository.Include(x => x.User).ToArray(x => !x.Error && !x.Sent && x.SendTime.Hour < DateTime.Now.Hour);
            var client = await Bot.Bot.Get();

            foreach (var el in messages)
            {
                try
                {
                    await _sender.SendMessage(el.Messages, el.User.TID, client);
                }
                catch (Exception)
                {
                    el.Error = true;
                }
                finally
                {
                    el.Sent = true;
                }
            }

            _saveChangesCommand.SaveChanges();
        }

        public void AddLessonsToSend()
        {
            var message = _messageBLL.GetActuallyMessages();

            foreach (var el in message)
            {
                _messageToSendRepository.Insert(el);
            }

            _saveChangesCommand.SaveChanges();
        }

        public void DeleteAllSentMessages()
        {
            var sentMessages = _messageToSendRepository.Include(x => x.User).ToArray();

            var grouped = sentMessages.GroupBy(x => x.Error);
            var failedUsers = grouped.Where(x => x.Key == true).SelectMany(x => x).Select(x => x.User.ID).ToArray();
            var successUsers = sentMessages.Select(x => x.User.ID).Distinct().Except(failedUsers).ToArray();

            _payedUserBLL.RecalculateNextMessage(successUsers);
        }
    }
}
