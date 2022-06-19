using IvritSchool.Data;
using IvritSchool.Finder;
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

    }
}
