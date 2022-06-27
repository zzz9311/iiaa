using IvritSchool.Data;
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
        private readonly IRepository<Entities.Message> _repository;
        private readonly IFinder<Entities.Message> _finder;
        private readonly ISaveChangesCommand _saveChangesCommand;
        public MessageBLL(IRepository<Entities.Message> repository,
                          IFinder<Entities.Message> finder,
                          ISaveChangesCommand saveChangesCommand)
        {
            _repository = repository;
            _finder = finder;
            _saveChangesCommand = saveChangesCommand;
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

    }
}
